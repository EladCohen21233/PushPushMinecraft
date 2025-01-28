using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        // פעולה שתופסת את כפתור ה-Submit
        [HttpPost]
        public IActionResult StartServer()
        {
            try
            {
                // נתיב לקובץ run.bat
                string serverPath = @"F:\Server\run.bat"; // שים לב שהנתיב מדויק

                // יצירת תהליך חדש והפעלת קובץ ה-BAT
                ProcessStartInfo startInfo = new ProcessStartInfo()
                {
                    FileName = serverPath,
                    UseShellExecute = true,  // שימוש בהפעלה של Shell, כך אפשר להריץ את קובץ ה-BAT
                    CreateNoWindow = true,   // אל תיצור חלון חדש
                    WorkingDirectory = Path.GetDirectoryName(serverPath) // לקבוע את תיקיית העבודה
                };
                Process.Start(startInfo);

                // החזרת הפניה מחדש לדף הבית לאחר ההפעלה
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // טיפול בשגיאות
                return View("Error", ex.Message);
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
