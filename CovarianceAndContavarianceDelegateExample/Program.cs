namespace CovarianceAndContavarianceDelegateExample
{
    internal class Program
    {
        delegate Animal AnimalReturner(string name, int age); // covariance

        delegate void LogDogDetails(Dog dog); // contravariance
        delegate void LogCatDetails(Cat cat); // contravariance

        static void Main(string[] args)
        {
            AnimalReturner animalReturner = AnimalFactory.ReturnDog;
            Animal dog = animalReturner("Buddy", 3);
            //Console.WriteLine(dog.GetAnimalInfo());

            animalReturner = AnimalFactory.ReturnCat;
            Animal cat = animalReturner("Whiskers", 2);
            //Console.WriteLine(cat.GetAnimalInfo());

            LogDogDetails logDogDetails = LogAnimalInfo;
            logDogDetails(dog as Dog);
            LogCatDetails logCatDetails = LogAnimalInfo;
            logCatDetails(cat as Cat);
        }

        static void LogAnimalInfo(Animal animal)
        {
            if (animal is Dog)
            {
                using (StreamWriter writer = new StreamWriter("dog_log.txt", true))
                {
                    writer.WriteLine(animal.GetAnimalInfo());
                    Console.WriteLine("Dog log written!");
                }
            }
            else if (animal is Cat)
            {
                using (StreamWriter writer = new StreamWriter("cat_log.txt", true))
                {
                    writer.WriteLine(animal.GetAnimalInfo());
                    Console.WriteLine("Cat log written!");
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public static class AnimalFactory
        {
            public static Dog ReturnDog(string name, int age)
            {
                return new Dog { Name = name, Age = age };
            }

            public static Cat ReturnCat(string name, int age)
            {
                return new Cat { Name = name, Age = age };
            }
        }


        public abstract class Animal
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public virtual string GetAnimalInfo()
            {
                return $"Name: {Name}, Age: {Age}";
            }
        }

        public class Dog : Animal
        {
            public override string GetAnimalInfo()
            {
                return $"Dog - {base.GetAnimalInfo()}";
            }
        }

        public class Cat : Animal
        {
            public override string GetAnimalInfo()
            {
                return $"Cat - {base.GetAnimalInfo()}";
            }
        }
    }
}
