using System;
using System.IO;

namespace OrganizacionProgramacion
{
    class Program
    {
        static void LeerCantidades(out int[] cantidades, string lectura)
        {

            cantidades = new int[10];
            StreamReader lee = new StreamReader(lectura);
            for (int i = 0; i < 10; i++)
            {
                cantidades[i] = int.Parse(lee.ReadLine());
            }
            lee.Close();
        }
        static void ImprimirCantidades(int[] cantidades, string imprime)
        {
            StreamWriter escribe = new StreamWriter(imprime);
            for (int i = 0; i < cantidades.Length; i++)
            {
                escribe.WriteLine(cantidades[i]);
            }
            escribe.Close();
        }
        static void AñadirHistoria(string persona1, string persona2, string historia)
        {

            StreamReader leer1 = new StreamReader("../../../" + persona1 + ".txt");
            StreamReader leer2 = new StreamReader("../../../" + persona2 + ".txt");
            string s1 = leer1.ReadToEnd();
            string s2 = leer2.ReadToEnd();
            leer1.Close();
            leer2.Close();
            StreamWriter escribir1 = new StreamWriter("../../../" + persona1 + ".txt");
            StreamWriter escribir2 = new StreamWriter("../../../" + persona2 + ".txt");

            escribir1.WriteLine(s1 + "\n" + historia);
            escribir2.WriteLine(s2 + "\n" + historia);
            escribir1.Close();
            escribir2.Close();
        }
        static void Main(string[] args)
        {
            bool persona1 = false, persona2 = false;
            string personaE1 = "", personaE2 = "", seguir;

            string[] personas = { "leyre", "paula", "aida", "aurora", "amaro", "oscar", "dani", "georgi", "stiven", "agus" };
            int[] cantidades;
            LeerCantidades(out cantidades, "../../../cantidades.txt");

            do
            {
                persona1 = false;
                persona2 = false;
                Console.WriteLine("Estas son las personas y sus respectivas cantidades de historias asignadas hasta el momento ");
                for (int i = 0; i < 10; i++) Console.WriteLine(personas[i] + " " + cantidades[i]);
                Console.WriteLine("Que 2 personas quieres asignar a esta historia");
                personaE1 = Console.ReadLine().ToLower();
                personaE2 = Console.ReadLine().ToLower();
                while (!persona1 || !persona2)
                {
                    int cont = 0;
                    while (cont < 10 && !persona1)
                    {
                        persona1 = personaE1.Equals(personas[cont]);
                        if (!persona1)
                            cont++;
                    }
                    if (!persona1)
                    {
                        Console.WriteLine("La primera persona que has introducido no pertenece al grupo");
                        personaE1 = Console.ReadLine().ToLower();
                    }
                    else
                    {
                        cantidades[cont] += 1;
                    }
                    cont = 0;
                    while (cont < 10 && !persona2)
                    {
                        persona2 = personaE2.Equals(personas[cont]);
                        if (!persona2)
                            cont++;
                    }
                    if (!persona2)
                    {
                        Console.WriteLine("La segunda persona que has introducido no pertenece al grupo");
                        personaE2 = Console.ReadLine().ToLower();
                    }
                    else
                    {
                        cantidades[cont] += 1;
                    }
                }
                Console.WriteLine("Que historia vas a asignar?");
                string historia = Console.ReadLine();
                AñadirHistoria(personaE1, personaE2, historia);
                Console.WriteLine("Quieres añadir otra historia? Si o no ");
                seguir = Console.ReadLine().ToLower();
            } while (seguir.Equals("si"));
            ImprimirCantidades(cantidades, "../../../cantidades.txt");
        }
    }
}
