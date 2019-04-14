using System;
using System.Collections.Generic;
using System.Linq;

namespace ClaseLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Linq1();
            Linq2();
            Linq3();
            Linq4();
        }

        static void Linq1()
        {
            int[] lista = new int[3] { 1, 8, 2 };

            IEnumerable<int> listaFiltrada = from elemento in lista
                                             where elemento < 8
                                             select elemento;
            Console.ReadKey();
        }

        static void Linq2()
        {
            // LINQ con objetos
            IEnumerable<Person> personas = Person.GenerarLista();


            IEnumerable<string> nombres = from persona in personas where persona.edad < 30 select persona.nombre;
            Console.ReadKey();
        }

        static void Linq3()
        { 
            IEnumerable<Person> personas = Person.GenerarLista();

            IEnumerable<string> nombres = personas
                                            .Where(x => x.edad < 30)
                                            .Select(x => x.nombre);
            Console.ReadKey();
        }

        static void Linq4()
        {
            var listaPersonas = Person.GenerarLista();

            IEnumerable<IGrouping<int, Person>> agrupaciones = listaPersonas
                .Where(x => x.edad > 10)
                .GroupBy(persona => persona.GetEdad());

            foreach (IGrouping<int, Person> grupo in agrupaciones)
            {
                Console.WriteLine($"Elemento del tipo {grupo.GetType().Name}, con key: {grupo.Key}");

                foreach (Person elemento in grupo)
                {
                    Console.WriteLine($"Nombre: {elemento.nombre}, Edad: {elemento.edad}");
                }
            }
            Console.ReadKey();
        }

        static void Linq5()
        {
            IEnumerable<Person> listaPersonas = Person.GenerarLista();

            Person persona = listaPersonas
                .FirstOrDefault(/*x => x.edad ==30*/);
                //.LastOrDefault(x => x.edad ==30);

            double promedio = listaPersonas
                .Select(x => x.edad)
                .Average();
        }
    }

    #region Clases
    public class Person
    {
        public int edad;
        public string nombre;

        public Person(int edad, string nombre)
        {
            this.edad = edad;
            this.nombre = nombre;
        }

        public int GetEdad()
        {
            return this.edad;
        }

        public int GetEdadLambda() => this.edad;

        public static IEnumerable<Person> GenerarLista()
        {
            return new List<Person>()
            {
                new Person(30,"Demian"),
                new Person(30,"Alejandro"),
                new Person(20,"Ana"),
                new Person(10,"Conejo Pepito")
            };
        }
    }
    #endregion
}
