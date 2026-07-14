// Mengelola data Person
List<Person> people = new();
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

}