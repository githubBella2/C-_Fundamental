// Mengelola data Person
public class PersonService
{
    //  Encapsulation
    private List<Person> people = new();

    public Person CreatePerson()
    {
        Console.Write("Nama : ");
        string? name = Console.ReadLine();

        Console.Write("Umur : ");
        int age;
        while (!int.TryParse(Console.ReadLine(), out age))
        {
            Console.Write("Umur harus angka. Masukkan lagi : ");
        }

        Console.Write("Tinggi Badan : ");
        double height;
        while (!double.TryParse(Console.ReadLine(), out height))
        {
            Console.Write("Tinggi harus angka. Masukkan lagi : ");
        }

        return new Person
        {
            Name = name ?? "",
            Age = age,
            Height = height
        };
    }

    public void AddPerson()
    {
        Person person = CreatePerson();

        people.Add(person);

        Console.WriteLine("Data berhasil ditambahkan.");
    }

    public void PrintPeople()
    {
        // foreach (Person person in people)
        // {
        //     System.Console.WriteLine($"""
        //         ======Biodata======
        //         Nama            :{person.Name}
        //         Umur            : {person.Age}
        //         Tinggi badan    : {person.Height}
        //         ===================
        //         """);
        // }

        // **Reuse method yang sudah ada** 
        int nomor = 1;
        foreach (Person person in people)
        {
            System.Console.WriteLine($"Orang ke {nomor}");
            PrintPerson(person);
            nomor++;
        }
    }

    private void PrintPerson(Person person)
    {
        System.Console.WriteLine($"""
======Biodata======
Nama            :{person.Name}
Umur            : {person.Age}
Tinggi badan    : {person.Height}
===================
""");
    }

    public void SearchPerson()
    {
        System.Console.Write("Masukkan Nama : ");
        string? keyword = Console.ReadLine();

        bool ditemukan = false;

        foreach (Person person in people)
        {
            if (person.Name.Equals(keyword, StringComparison.OrdinalIgnoreCase))
            {
                PrintPerson(person);
                ditemukan = true;
            }
        }

        if (!ditemukan)
        {
            System.Console.WriteLine("Data tidak ditemukan");
        }
    }

    public void FindAdult()
    {
        Person? person = people.FirstOrDefault(p => p.Age > 20);

        if (person == null)
        {
            System.Console.WriteLine("Tidak ada");
            return;
        }
        PrintPerson(person);
    }
    public void DeletePerson()

    {
        System.Console.WriteLine("Masukkan Nama: ");
        string? keyword = Console.ReadLine();

        Person? person = people.FirstOrDefault(p => p.Name.Equals(keyword, StringComparison.OrdinalIgnoreCase));
        if (person == null)
        {
            System.Console.WriteLine("Data tidak ditemukan.");
        }
        people.Remove(person);
        System.Console.WriteLine("Data berhasil dihapus");

    }

}