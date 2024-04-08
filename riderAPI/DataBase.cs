namespace riderAPI.Modele;

public class DataBase
{
    public static List<Animal> animals = new()
    {
        new Animal { id = 1, name = "a1", category = "dawg", mass = 26.6, furColor = "chocolate" },
        new Animal { id = 2, name = "a2", category = "cawt", mass = 6.5, furColor = "caramel" },
        new Animal { id = 3, name = "a3", category = "hippaw", mass = 666.9, furColor = "grey" },
        new Animal { id = 4, name = "a4", category = "oawl", mass = 8.4, furColor = "brownish" },
        new Animal { id = 5, name = "a5", category = "rawt", mass = 0.3, furColor = "white" }
    };
}