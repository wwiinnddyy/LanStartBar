using System;
using System.Linq;
using System.Reflection;

class InspectJalium
{
    static void Main()
    {
        var controls = Assembly.LoadFrom(@"C:\Users\USER154971\.nuget\packages\jalium.ui.controls\26.10.1-preview.3\lib\net10.0\Jalium.UI.Controls.dll");
        var core = Assembly.LoadFrom(@"C:\Users\USER154971\.nuget\packages\jalium.ui.core\26.10.1-preview.3\lib\net10.0\Jalium.UI.Core.dll");

        var windowType = controls.GetTypes().FirstOrDefault(t => t.Name == "Window");
        if (windowType == null)
        {
            Console.WriteLine("Window type not found");
            return;
        }

        Console.WriteLine("=== Window Properties ===");
        foreach (var prop in windowType.GetProperties().OrderBy(p => p.Name))
        {
            Console.WriteLine($"{prop.PropertyType.Name} {prop.Name}");
        }

        Console.WriteLine();
        Console.WriteLine("=== Types containing Backdrop/Mica/Acrylic ===");
        foreach (var asm in new[] { controls, core })
        {
            foreach (var t in asm.GetTypes().Where(t => t.Name.Contains("Backdrop") || t.Name.Contains("Mica") || t.Name.Contains("Acrylic") || t.Name.Contains("Material")))
            {
                Console.WriteLine(t.FullName);
            }
        }
    }
}
