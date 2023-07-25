using SOLID_Exercise.Models.Contracts;

namespace SOLID_Exercise.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
