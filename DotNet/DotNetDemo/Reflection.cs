using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace DotNetDemo
{
   public class Reflection
    {
        public void TestReflection()
        {
            Assembly assembly = null;
            Type type = null;
            XmlDocument doc = null;

            try
            {
                // Load the requested assembly and get the requested type
                assembly = Assembly.LoadFrom("C:\\WINNT\\Microsoft.NET\\Framework\\v1.0.2914\\System.XML.dll");
                type = assembly.GetType("System.Xml.XmlDocument", true);

                //Unfortunately one cannot dynamically instantiate types via the Type object in C#. 
                doc = Activator.CreateInstance(type) as XmlDocument;

                if (doc != null)
                    Console.WriteLine(doc.GetType() + " was created at runtime");
                else
                    Console.WriteLine("Could not dynamically create object at runtime");

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not load Assembly: system.xml.dll");
                return;
            }
            catch (TypeLoadException)
            {
                Console.WriteLine("Could not load Type: System.Xml.XmlDocument from assembly: system.xml.dll");

                return;
            }
            catch (MissingMethodException)
            {
                Console.WriteLine("Cannot find default constructor of " + type);
            }
            catch (MemberAccessException)
            {
                Console.WriteLine("Could not create new XmlDocument instance");
            }

            // Get the methods from the type
            MethodInfo[] methods = type.GetMethods();

            //print the method signatures and parameters
            for (int i = 0; i < methods.Length; i++)
            {

                Console.WriteLine("{0}", methods[i]);

                ParameterInfo[] parameters = methods[i].GetParameters();

                for (int j = 0; j < parameters.Length; j++)
                {
                    Console.WriteLine(" Parameter: {0} {1}", parameters[j].ParameterType, parameters[j].Name);
                }

            }//for (int i...)
        }
    }
}
