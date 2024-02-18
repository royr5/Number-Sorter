using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Number_Sorter.Data;
using Number_Sorter.Models;
using System.Text.Json;
using System.Text;


namespace Number_Sorter.Controllers
{
    public class NumberSortsController : Controller
    {
        private readonly Number_SorterContext _context;

        public NumberSortsController(Number_SorterContext context)
        {
            _context = context;
        }

        // GET: NumberSorts
        public async Task<IActionResult> Index()
        {
            return View(await _context.NumberSort.ToListAsync());
        }


        // GET: NumberSorts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NumberSorts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SortedNumbers,SortedDirection,SortTime")] NumberSort numberSort)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    // Turns string of numbers separated by commas into array of numbers.
                    int[] nums = Array.ConvertAll(numberSort.SortedNumbers.Split(','), int.Parse);

                    // Starts the stopwatch to record the time taken to do the sort.
                    var time = Stopwatch.StartNew();

                    if (numberSort.SortedDirection == "Ascending")
                    {
                        // Sorts array of numbers in ascending order.
                        Array.Sort(nums);

                    }
                    else if (numberSort.SortedDirection == "Descending")
                    {
                        // Sorts array of numbers in descending order.
                        Array.Sort(nums);
                        Array.Reverse(nums);
                    }

                    // Stops the stopwatch to record the time taken to do the sort.
                    time.Stop();

                    // Changes SortedNumbers from an array of numbers to a string of comma separated numbers that are sorted.
                    numberSort.SortedNumbers = string.Join(",", nums);

                    // SortTime is also recorded in milliseconds in the database.
                    numberSort.SortTime = time.Elapsed.TotalMilliseconds;


                    _context.Add(numberSort);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Your numbers have been sorted.";
                    return RedirectToAction(nameof(Index));

                }
                catch
                {
                    TempData["ErrorMessage"] = "Your numbers have'nt been sorted.";

                }

            }
            return View(numberSort);
        }

        public async Task<IActionResult> ExportToJson()
        {
            // numberSorts is all the values in the database as a List (objects).
            var numberSorts = await _context.NumberSort.ToListAsync();

            // jsonString converts the list numberSorts to a JSON formatted string.
            var jsonString = JsonSerializer.Serialize(numberSorts);

            // Turns jsonString into an array of bytes so the File method can be used.
            var byteArray = Encoding.UTF8.GetBytes(jsonString);

            // Downloads file called NumberSortsExport.json (3rd param) in json format (2nd param) and contents (1st param).
            return File(byteArray, "application/json", "NumberSortsExport.json");
        }


        private bool NumberSortExists(int id)
        {
            return _context.NumberSort.Any(e => e.Id == id);
        }
    }
}
