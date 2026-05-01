using System;
using Humanizer;

namespace Tests.Shared;

public static class Helpers
{
    public static List<string> Names() => 
    [
        "Michael", "Peter", "James", "Michel", "Jorge", "Lazaro", "Pedro", "Maria", "Mile", "Mille", 
        "Julia", "Lucia", "Samuel", "Alejandro", "Alexis", "Angelo", "Osmany", "Nivaldo", "Miguel", "Cristobal"
    ];
    public static List<string> Lastnames() =>
    [
        "Jackson", "Jefferson", "Romero", "Perez", "Saavedra", "Estevez", "Lopez", "Arencibia", "Montero", "Martinez", 
        "Marquez", "Gleider", "Gutierrez", "Abazcal", "Arcia", "Benitez", "Lache", "O'Relly", "Fernandez", "Lincoln"
    ];

    public static string RandomName() => Names()[new Random().Next(Names().Count - 1)];

    public static string RandomLastname() => Lastnames()[new Random().Next(Names().Count - 1)];

    public static string RandomFullname() => RandomName() + " " + RandomLastname();

    // public static string Fullname(int idx) => $"{Names()[idx]} {Lastnames()[idx]}";
}
