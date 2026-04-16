using LinqConsoleLab.PL.Data;
using LinqConsoleLab.PL.Models;

namespace LinqConsoleLab.PL.Exercises;

public sealed class ZadaniaLinq
{
    /// <summary>
    /// Zadanie:
    /// Wyszukaj wszystkich studentów mieszkających w Warsaw.
    /// Zwróć numer indeksu, pełne imię i nazwisko oraz miasto.
    ///
    /// SQL:
    /// SELECT NumerIndeksu, Imie, Nazwisko, Miasto
    /// FROM Studenci
    /// WHERE Miasto = 'Warsaw';
    /// </summary>
    public IEnumerable<string> Zadanie01_StudenciZWarszawy()
    {
        return DaneUczelni.Studenci.Where(s => s.Miasto == "Warsaw")
            .Select(s => $"{s.NumerIndeksu} | {s.Imie} | {s.Nazwisko} | {s.Miasto}");
        throw Niezaimplementowano(nameof(Zadanie01_StudenciZWarszawy));
    }

    /// <summary>
    /// Zadanie:
    /// Przygotuj listę adresów e-mail wszystkich studentów.
    /// Użyj projekcji, tak aby w wyniku nie zwracać całych obiektów.
    ///
    /// SQL:
    /// SELECT Email
    /// FROM Studenci;
    /// </summary>
    public IEnumerable<string> Zadanie02_AdresyEmailStudentow()
    {
        return DaneUczelni.Studenci.Select(s => s.Email);
        throw Niezaimplementowano(nameof(Zadanie02_AdresyEmailStudentow));
    }

    /// <summary>
    /// Zadanie:
    /// Posortuj studentów alfabetycznie po nazwisku, a następnie po imieniu.
    /// Zwróć numer indeksu i pełne imię i nazwisko.
    ///
    /// SQL:
    /// SELECT NumerIndeksu, Imie, Nazwisko
    /// FROM Studenci
    /// ORDER BY Nazwisko, Imie;
    /// </summary>
    public IEnumerable<string> Zadanie03_StudenciPosortowani()
    {
        return DaneUczelni.Studenci
            .OrderBy(s=> s.Nazwisko).ThenBy(s => s.Imie)
            .Select(s => $"{s.NumerIndeksu} | {s.Imie} | {s.Nazwisko}");
        throw Niezaimplementowano(nameof(Zadanie03_StudenciPosortowani));
    }

    /// <summary>
    /// Zadanie:
    /// Znajdź pierwszy przedmiot z kategorii Analytics.
    /// Jeżeli taki przedmiot nie istnieje, zwróć komunikat tekstowy.
    ///
    /// SQL:
    /// SELECT TOP 1 Nazwa, DataStartu
    /// FROM Przedmioty
    /// WHERE Kategoria = 'Analytics';
    /// </summary>
    public IEnumerable<string> Zadanie04_PierwszyPrzedmiotAnalityczny()
    {
        var top1 = DaneUczelni.Przedmioty
            .Where(s => s.Kategoria == "Analytics")
            .Take(1)
            .Select(s => $"{s.Nazwa} | {s.DataStartu}");

        if (!top1.Any())
            return new List<string> {"brak"};

        throw Niezaimplementowano(nameof(Zadanie04_PierwszyPrzedmiotAnalityczny));
    }

    /// <summary>
    /// Zadanie:
    /// Sprawdź, czy w danych istnieje przynajmniej jeden nieaktywny zapis.
    /// Zwróć jedno zdanie z odpowiedzią True/False albo Tak/Nie.
    ///
    /// SQL:
    /// SELECT CASE WHEN EXISTS (
    ///     SELECT 1
    ///     FROM Zapisy
    ///     WHERE CzyAktywny = 0
    /// ) THEN 1 ELSE 0 END;
    /// </summary>
    public IEnumerable<string> Zadanie05_CzyIstniejeNieaktywneZapisanie()
    {
        var result = DaneUczelni.Zapisy.Any(z => !z.CzyAktywny);
        return result ? new List<string> { "true" } : new List<string> { "fasle" };
        
        throw Niezaimplementowano(nameof(Zadanie05_CzyIstniejeNieaktywneZapisanie));
    }

    /// <summary>
    /// Zadanie:
    /// Sprawdź, czy każdy prowadzący ma uzupełnioną nazwę katedry.
    /// Warto użyć metody, która weryfikuje warunek dla całej kolekcji.
    ///
    /// SQL:
    /// SELECT CASE WHEN COUNT(*) = COUNT(Katedra)
    /// THEN 1 ELSE 0 END
    /// FROM Prowadzacy;
    /// </summary>
    public IEnumerable<string> Zadanie06_CzyWszyscyProwadzacyMajaKatedre()
    {
        //var result = DaneUczelni.Prowadzacy.Any(p => p.Katedra == null);
        //return result ? new List<string> { "true" } : new List<string> { "fasle" };
        // albo

        var n1 = DaneUczelni.Prowadzacy.Count();
        var n2 = DaneUczelni.Prowadzacy.Count(p => p.Katedra.Length > 0);
        
        return n1 == n2 ? new List<string> { "true" } : new List<string> { "fasle" };
        
        throw Niezaimplementowano(nameof(Zadanie06_CzyWszyscyProwadzacyMajaKatedre));
    }

    /// <summary>
    /// Zadanie:
    /// Policz, ile aktywnych zapisów znajduje się w systemie.
    ///
    /// SQL:
    /// SELECT COUNT(*)
    /// FROM Zapisy
    /// WHERE CzyAktywny = 1;
    /// </summary>
    public IEnumerable<string> Zadanie07_LiczbaAktywnychZapisow()
    {
        var n = DaneUczelni.Zapisy.Count(p => p.CzyAktywny);
        return new List<string> { n.ToString() };
        throw Niezaimplementowano(nameof(Zadanie07_LiczbaAktywnychZapisow));
    }

    /// <summary>
    /// Zadanie:
    /// Pobierz listę unikalnych miast studentów i posortuj ją rosnąco.
    ///
    /// SQL:
    /// SELECT DISTINCT Miasto
    /// FROM Studenci
    /// ORDER BY Miasto;
    /// </summary>
    public IEnumerable<string> Zadanie08_UnikalneMiastaStudentow()
    {
        return DaneUczelni.Studenci.Select(s => s.Miasto).Distinct().OrderBy(s => s);
        
        throw Niezaimplementowano(nameof(Zadanie08_UnikalneMiastaStudentow));
    }

    /// <summary>
    /// Zadanie:
    /// Zwróć trzy najnowsze zapisy na przedmioty.
    /// W wyniku pokaż datę zapisu, identyfikator studenta i identyfikator przedmiotu.
    ///
    /// SQL:
    /// SELECT TOP 3 DataZapisu, StudentId, PrzedmiotId
    /// FROM Zapisy
    /// ORDER BY DataZapisu DESC;
    /// </summary>
    public IEnumerable<string> Zadanie09_TrzyNajnowszeZapisy()
    {
        return DaneUczelni.Zapisy.OrderByDescending(p => p.DataZapisu).Take(3)
            .Select(z => $"{z.DataZapisu:yyyy-MM-dd} | Student: {z.StudentId} | Przedmiot: {z.PrzedmiotId}");
        throw Niezaimplementowano(nameof(Zadanie09_TrzyNajnowszeZapisy));
    }

    /// <summary>
    /// Zadanie:
    /// Zaimplementuj prostą paginację dla listy przedmiotów.
    /// Załóż stronę o rozmiarze 2 i zwróć drugą stronę danych.
    ///
    /// SQL:
    /// SELECT Nazwa, Kategoria
    /// FROM Przedmioty
    /// ORDER BY Nazwa
    /// OFFSET 2 ROWS FETCH NEXT 2 ROWS ONLY;
    /// </summary>
    public IEnumerable<string> Zadanie10_DrugaStronaPrzedmiotow()
    {
        return DaneUczelni.Przedmioty.OrderBy(p => p.Nazwa).Skip(2).Take(2).Select(p => $"{p.Nazwa} | {p.Kategoria}");
        throw Niezaimplementowano(nameof(Zadanie10_DrugaStronaPrzedmiotow));
    }

    /// <summary>
    /// Zadanie:
    /// Połącz studentów z zapisami po StudentId.
    /// Zwróć pełne imię i nazwisko studenta oraz datę zapisu.
    ///
    /// SQL:
    /// SELECT s.Imie, s.Nazwisko, z.DataZapisu
    /// FROM Studenci s
    /// JOIN Zapisy z ON s.Id = z.StudentId;
    /// </summary>
    public IEnumerable<string> Zadanie11_PolaczStudentowIZapisy()
    {
        return DaneUczelni.Studenci
            .Join(DaneUczelni.Zapisy
                , student => student.Id
                , zapis => zapis.StudentId
                , (student, zapis) => new { student = student, Zapis = zapis }
            )
            .Select(s => $"{s.student.Imie} | {s.student.Nazwisko} | {s.Zapis.DataZapisu}");
        throw Niezaimplementowano(nameof(Zadanie11_PolaczStudentowIZapisy));
    }

    /// <summary>
    /// Zadanie:
    /// Przygotuj wszystkie pary student-przedmiot na podstawie zapisów.
    /// Użyj podejścia, które pozwoli spłaszczyć dane do jednej sekwencji wyników.
    ///
    /// SQL:
    /// SELECT s.Imie, s.Nazwisko, p.Nazwa
    /// FROM Zapisy z
    /// JOIN Studenci s ON s.Id = z.StudentId
    /// JOIN Przedmioty p ON p.Id = z.PrzedmiotId;
    /// </summary>
    public IEnumerable<string> Zadanie12_ParyStudentPrzedmiot()
    {
        return DaneUczelni.Zapisy
            .Join(DaneUczelni.Studenci
                ,zapis => zapis.StudentId
                ,student => student.Id
                ,(zapis, student) => new {student = student, zapis = zapis}
                )
            .Join(DaneUczelni.Przedmioty
                ,arg1 => arg1.zapis.PrzedmiotId
                ,przedmioty => przedmioty.Id
                ,((arg1, przedmiot) => new {arg1 = arg1, przedmiot = przedmiot})
            ).Select(s =>  $"{s.arg1.student.Imie} | {s.arg1.student.Nazwisko} | {s.przedmiot.Nazwa}");
        throw Niezaimplementowano(nameof(Zadanie12_ParyStudentPrzedmiot));
    }

    /// <summary>
    /// Zadanie:
    /// Pogrupuj zapisy według przedmiotu i zwróć nazwę przedmiotu oraz liczbę zapisów.
    ///
    /// SQL:
    /// SELECT p.Nazwa, COUNT(*)
    /// FROM Zapisy z
    /// JOIN Przedmioty p ON p.Id = z.PrzedmiotId
    /// GROUP BY p.Nazwa;
    /// </summary>
    public IEnumerable<string> Zadanie13_GrupowanieZapisowWedlugPrzedmiotu()
    {
        return DaneUczelni.Zapisy
            .Join(DaneUczelni.Przedmioty, zapis => zapis.PrzedmiotId, przedmiot => przedmiot.Id, (zapis, przedmiot) => przedmiot.Nazwa)
            .GroupBy(przedmiot => przedmiot)
            .Select(grupy => $"{grupy.Key} | {grupy.Count()}");
        
        throw Niezaimplementowano(nameof(Zadanie13_GrupowanieZapisowWedlugPrzedmiotu));
    }

    /// <summary>
    /// Zadanie:
    /// Oblicz średnią ocenę końcową dla każdego przedmiotu.
    /// Pomiń rekordy, w których ocena końcowa ma wartość null.
    ///
    /// SQL:
    /// SELECT p.Nazwa, AVG(z.OcenaKoncowa)
    /// FROM Zapisy z
    /// JOIN Przedmioty p ON p.Id = z.PrzedmiotId
    /// WHERE z.OcenaKoncowa IS NOT NULL
    /// GROUP BY p.Nazwa;
    /// </summary>
    public IEnumerable<string> Zadanie14_SredniaOcenaNaPrzedmiot()
    {
       return DaneUczelni.Zapisy.Where(z => z.OcenaKoncowa != null)
            .Join(DaneUczelni.Przedmioty, zapis => zapis.PrzedmiotId, przedmiot => przedmiot.Id, (zapis, przedmiot) => new {przedmiot.Nazwa, zapis.OcenaKoncowa})
            .GroupBy(przedmiot => przedmiot.Nazwa)
            .Select(grupy => $"{grupy.Key} | {grupy.Average(x => x.OcenaKoncowa)}");

        
        throw Niezaimplementowano(nameof(Zadanie14_SredniaOcenaNaPrzedmiot));
    }

    /// <summary>
    /// Zadanie:
    /// Dla każdego prowadzącego policz liczbę przypisanych przedmiotów.
    /// W wyniku zwróć pełne imię i nazwisko oraz liczbę przedmiotów.
    ///
    /// SQL:
    /// SELECT pr.Imie, pr.Nazwisko, COUNT(p.Id)
    /// FROM Prowadzacy pr
    /// LEFT JOIN Przedmioty p ON p.ProwadzacyId = pr.Id
    /// GROUP BY pr.Imie, pr.Nazwisko;
    /// </summary>
    public IEnumerable<string> Zadanie15_ProwadzacyILiczbaPrzedmiotow()
    {
        return DaneUczelni.Prowadzacy
            .Join(
                DaneUczelni.Przedmioty,
                prof => prof.Id,            
                przed => przed.ProwadzacyId, 
                (prof, przed) => new { prof.Imie, prof.Nazwisko, PrzedmiotId = przed.Id }
            )
            .GroupBy(arg1 => new { arg1.Imie, arg1.Nazwisko })
            .Select(grupy => $"{grupy.Key.Imie} {grupy.Key.Nazwisko}: {grupy.Count()}");
        throw Niezaimplementowano(nameof(Zadanie15_ProwadzacyILiczbaPrzedmiotow));
    }

    /// <summary>
    /// Zadanie:
    /// Dla każdego studenta znajdź jego najwyższą ocenę końcową.
    /// Pomiń studentów, którzy nie mają jeszcze żadnej oceny.
    ///
    /// SQL:
    /// SELECT s.Imie, s.Nazwisko, MAX(z.OcenaKoncowa)
    /// FROM Studenci s
    /// JOIN Zapisy z ON s.Id = z.StudentId
    /// WHERE z.OcenaKoncowa IS NOT NULL
    /// GROUP BY s.Imie, s.Nazwisko;
    /// </summary>
    public IEnumerable<string> Zadanie16_NajwyzszaOcenaKazdegoStudenta()
    {
       
        return DaneUczelni.Studenci
            .Join(
                DaneUczelni.Zapisy.Where(z => z.OcenaKoncowa != null),
                s => s.Id,
                z => z.StudentId,
                (s, z) => new { s.Imie, s.Nazwisko, z.OcenaKoncowa }
            )
            .GroupBy(x => new { x.Imie, x.Nazwisko })
            .Select(g => $"{g.Key.Imie} | {g.Key.Nazwisko} | {g.Max(x => x.OcenaKoncowa)}");
        throw Niezaimplementowano(nameof(Zadanie16_NajwyzszaOcenaKazdegoStudenta));
    }

    /// <summary>
    /// Wyzwanie:
    /// Znajdź studentów, którzy mają więcej niż jeden aktywny zapis.
    /// Zwróć pełne imię i nazwisko oraz liczbę aktywnych przedmiotów.
    ///
    /// SQL:
    /// SELECT s.Imie, s.Nazwisko, COUNT(*)
    /// FROM Studenci s
    /// JOIN Zapisy z ON s.Id = z.StudentId
    /// WHERE z.CzyAktywny = 1
    /// GROUP BY s.Imie, s.Nazwisko
    /// HAVING COUNT(*) > 1;
    /// </summary>
    public IEnumerable<string> Wyzwanie01_StudenciZWiecejNizJednymAktywnymPrzedmiotem()
    {
        return DaneUczelni.Studenci
            .Join(
                DaneUczelni.Zapisy.Where(z => z.CzyAktywny),
                s => s.Id,
                z => z.StudentId,
                (s, z) => new { s.Imie, s.Nazwisko }
            )
            .GroupBy(x => new { x.Imie, x.Nazwisko })
            .Where(g => g.Count() > 1)
            .Select(g => $"{g.Key.Imie} | {g.Key.Nazwisko} | {g.Count()}");
        throw Niezaimplementowano(nameof(Wyzwanie01_StudenciZWiecejNizJednymAktywnymPrzedmiotem));
    }

    /// <summary>
    /// Wyzwanie:
    /// Wypisz przedmioty startujące w kwietniu 2026, dla których żaden zapis nie ma jeszcze oceny końcowej.
    ///
    /// SQL:
    /// SELECT p.Nazwa
    /// FROM Przedmioty p
    /// JOIN Zapisy z ON p.Id = z.PrzedmiotId
    /// WHERE MONTH(p.DataStartu) = 4 AND YEAR(p.DataStartu) = 2026
    /// GROUP BY p.Nazwa
    /// HAVING SUM(CASE WHEN z.OcenaKoncowa IS NOT NULL THEN 1 ELSE 0 END) = 0;
    /// </summary>
    public IEnumerable<string> Wyzwanie02_PrzedmiotyStartujaceWKwietniuBezOcenKoncowych()
    {
        throw Niezaimplementowano(nameof(Wyzwanie02_PrzedmiotyStartujaceWKwietniuBezOcenKoncowych));
    }

    /// <summary>
    /// Wyzwanie:
    /// Oblicz średnią ocen końcowych dla każdego prowadzącego na podstawie wszystkich jego przedmiotów.
    /// Pomiń brakujące oceny, ale pozostaw samych prowadzących w wyniku.
    ///
    /// SQL:
    /// SELECT pr.Imie, pr.Nazwisko, AVG(z.OcenaKoncowa)
    /// FROM Prowadzacy pr
    /// LEFT JOIN Przedmioty p ON p.ProwadzacyId = pr.Id
    /// LEFT JOIN Zapisy z ON z.PrzedmiotId = p.Id
    /// WHERE z.OcenaKoncowa IS NOT NULL
    /// GROUP BY pr.Imie, pr.Nazwisko;
    /// </summary>
    public IEnumerable<string> Wyzwanie03_ProwadzacyISredniaOcenNaIchPrzedmiotach()
    {
        throw Niezaimplementowano(nameof(Wyzwanie03_ProwadzacyISredniaOcenNaIchPrzedmiotach));
    }

    /// <summary>
    /// Wyzwanie:
    /// Pokaż miasta studentów oraz liczbę aktywnych zapisów wykonanych przez studentów z danego miasta.
    /// Posortuj wynik malejąco po liczbie aktywnych zapisów.
    ///
    /// SQL:
    /// SELECT s.Miasto, COUNT(*)
    /// FROM Studenci s
    /// JOIN Zapisy z ON s.Id = z.StudentId
    /// WHERE z.CzyAktywny = 1
    /// GROUP BY s.Miasto
    /// ORDER BY COUNT(*) DESC;
    /// </summary>
    public IEnumerable<string> Wyzwanie04_MiastaILiczbaAktywnychZapisow()
    {
        throw Niezaimplementowano(nameof(Wyzwanie04_MiastaILiczbaAktywnychZapisow));
    }

    private static NotImplementedException Niezaimplementowano(string nazwaMetody)
    {
        return new NotImplementedException(
            $"Uzupełnij metodę {nazwaMetody} w pliku Exercises/ZadaniaLinq.cs i uruchom polecenie ponownie.");
    }
}
