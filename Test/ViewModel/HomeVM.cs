using Test.Settings;

namespace Test.ViewModel
{
    public class HomeVM
    {
        public List<string> info { get; set; }
        public CompanySettings Company { get; set; }
        public HomeVM() { 
            info = new List<string>();
            Company = new CompanySettings();            
        }

    }
}
