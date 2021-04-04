using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Autofac;

namespace Nhtid.WinForms
{
    public static class AutofacExtensions
    {
        /// <summary>
        /// Calls all methods named 'AutoWire' on the specified controls.
        /// </summary>
        /// <param name="scope">The scope from which to resolve any parameter values.</param>
        /// <param name="controls">The controls to invoke AutoWire on.</param>
        /// <param name="recurse">If true then the entire control tree is considered, else just the top level.</param>
        public static void AutoWire(this ILifetimeScope scope, Control.ControlCollection controls, bool recurse = true)
        {
            if (controls != null && controls.Count > 0)
            {
                foreach (Control control in controls)
                {
                    Type controlType = control.GetType();
                    MethodInfo[] autoWireMethods =
                        controlType.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                            .Where(i => i.Name.Equals("AutoWire", StringComparison.OrdinalIgnoreCase)).ToArray();
                    foreach (var autoWireMethod in autoWireMethods)
                    {
                        var argInfos = autoWireMethod.GetParameters();
                        object[] argValues = new object[argInfos.Length];
                        for (int i = 0; i < argInfos.Length; i++)
                        {
                            argValues[i] = scope.Resolve(argInfos[i].ParameterType);
                        }

                        autoWireMethod.Invoke(control, argValues);
                    }

                    if (recurse)
                    {
                        AutoWire(scope, control.Controls);
                    }
                }
            }
        }
    }
}