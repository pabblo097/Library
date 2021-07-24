using Library.Models.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL
{
    public class LibraryContext : IdentityDbContext<User, Role, int>
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Fluent API commands
            modelBuilder.Entity<User>()
            .ToTable("AspNetUsers")
            .HasDiscriminator<int>("UserType")
            .HasValue<User>((int)RoleValue.User)
            .HasValue<Student>((int)RoleValue.Student)
            .HasValue<Reader>((int)RoleValue.Reader)
            .HasValue<Teacher>((int)RoleValue.Teacher)
            .HasValue<Admin>((int)RoleValue.Admin);



            //seedowanie danych

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 1,
                Name = "Harry Potter i Kamie� Filozoficzny",
                Author = "J.K. Rowling",
                Genre = "Literatura m�odzie�owa",
                ShortDescription = "Harry Potter, sierota i podrzutek, od niemowl�cia wychowywany by� przez ciotk� i wuja, kt�rzy traktowali go jak pi�te ko�o u wozu. Pochodzenie ch�opca owiane jest tajemnic�; jedyn� pami�tk� Harry`ego z przesz�o�ci jest zagadkowa blizna na czole.",
                LongDescription = "Harry Potter, sierota i podrzutek, od niemowl�cia wychowywany by� przez ciotk� i wuja, kt�rzy traktowali go jak pi�te ko�o u wozu. Pochodzenie ch�opca owiane jest tajemnic�; jedyn� pami�tk� Harry`ego z przesz�o�ci jest zagadkowa blizna na czole. Sk�d jednak bior� si� niesamowite zjawiska, kt�re towarzysz� nie�wiadomemu niczego Potterowi? Wszystko zmienia si� w dniu jedenastych urodzin ch�opca, kiedy dowiaduje si� o istnieniu �wiata, o kt�rym nie mia� dot�d poj�cia.Nowe wydanie ksi��ki o najs�ynniejszym czarodzieju �wiata r�ni si� od poprzednich nie tylko ok�adk�, ale i wn�trzem � po raz pierwszy na pocz�tku ka�dego tomu pojawi si� mapka Hogwartu i okolic, pocz�tki rozdzia��w ozdobione b�d� specjalnymi gwiazdkami, a na ko�cu pierwszego tomu na Czytelnik�w czeka co� zupe�nie wyj�tkowego � akt personalny J.K.Rowling, z kt�rego mo�na dowiedzie� si�, jakie jest ulubione zwierz� czy bohater literacki autorki.",
                Publisher = "Media Rodzina",
                Year = 1997,
                NumberOfPages = 328,
                Count = 3
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 2,
                Name = "Harry Potter i Komnata Tajemnic",
                Author = "J.K. Rowling",
                Genre = "Literatura m�odzie�owa",
                ShortDescription = "Harry po pe�nym przyg�d roku w Hogwarcie sp�dza nudne wakacje u Dursley�w i z ut�sknieniem wyczekuje powrotu do szko�y. Sprawy jednak znacznie si� komplikuj�, gdy pewnego dnia odwiedza go tajemniczy przybysz i ostrzega przed� powrotem do Szko�y Magii i Czarodziejstwa, gdzie ma doj�� do strasznych wydarze�.",
                LongDescription = "Harry po pe�nym przyg�d roku w Hogwarcie sp�dza nudne wakacje u Dursley�w i z ut�sknieniem wyczekuje powrotu do szko�y. Sprawy jednak znacznie si� komplikuj�, gdy pewnego dnia odwiedza go tajemniczy przybysz i ostrzega przed� powrotem do Szko�y Magii i Czarodziejstwa, gdzie ma doj�� do strasznych wydarze�. Czy Harry pos�ucha ostrze�enia? Co z�ego ma si� wydarzy� w Hogwarcie? Jakie tajemnice skrywa rodzina Malforya? I najwa�niejsze � czym jest i gdzie znajduje si� tytu�owa Komnata Tajemnic? Nowe wydanie r�ni si� od poprzednich nie tylko ok�adk�, ale i wn�trzem � po raz pierwszy na pocz�tku ka�dego tomu pojawi si� mapka Hogwartu i okolic, a pocz�tki rozdzia��w ozdobione b�d� specjalnymi gwiazdkami.",
                Publisher = "Media Rodzina",
                Year = 1998,
                NumberOfPages = 368,
                Count = 3
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 3,
                Name = "Harry Potter i wi�zie� Azkabanu",
                Author = "J.K. Rowling",
                Genre = "Literatura m�odzie�owa",
                ShortDescription = "Z pilnie strze�onego wi�zienia dla czarodziej�w ucieka niebezpieczny przest�pca. Kim jest? Co go ��czy z Harrym? Dlaczego lekcje przepowiadania przysz�o�ci staj� si� dla bohatera udr�k�?",
                LongDescription = "Z pilnie strze�onego wi�zienia dla czarodziej�w ucieka niebezpieczny przest�pca. Kim jest? Co go ��czy z Harrym? Dlaczego lekcje przepowiadania przysz�o�ci staj� si� dla bohatera udr�k�? W trzecim tomie przyg�d Harry`ego Pottera poznajemy nowego nauczyciela obrony przed czarn� magi�, ogl�damy Hagrida w nowej roli oraz dowiadujemy si� wi�cej o przesz�o�ci profesora Snape`a. Wyprawiamy si� r�wnie� wraz z trzecioklasistami do obfituj�cego w atrakcje Hogsmeade, jedynej wioski w Anglii zamieszkanej wy��cznie przez czarodziej�w. Nowe wydanie ksi��ki o najs�ynniejszym czarodzieju �wiata r�ni si� od poprzednich nie tylko ok�adk�, ale i wn�trzem � po raz pierwszy na pocz�tku ka�dego tomu pojawi si� mapka Hogwartu i okolic, a pocz�tki rozdzia��w ozdobione b�d� specjalnymi gwiazdkami.",
                Publisher = "Media Rodzina",
                Year = 1999,
                NumberOfPages = 450,
                Count = 3
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 4,
                Name = "Harry Potter i Czara Ognia",
                Author = "J.K. Rowling",
                Genre = "Literatura m�odzie�owa",
                ShortDescription = "W tym roku w Szkole Magii i Czarodziejstwa Hogwart rozegra si� Turniej Tr�jmagiczny, na kt�ry przyb�d� uczniowie z Bu�garii i Francjii. Zgodnie z prastarymi regu�ami w turnieju uczestniczy� ma trzech uczni�w",
                LongDescription = "W tym roku w Szkole Magii i Czarodziejstwa Hogwart rozegra si� Turniej Tr�jmagiczny, na kt�ry przyb�d� uczniowie z Bu�garii i Francjii. Zgodnie z prastarymi regu�ami w turnieju uczestniczy� ma trzech uczni�w - reprezentant�w ka�dej ze szk�, wybranych przez Czar� Ognia. W tajemniczych i niewyja�nionych okoliczno�ciach wybranych zostaje czterech. Co z tego wyniknie dla Harry'ego, jego przyjaci� i ca�ego �wiata czarodziej�w, dowiecie si� z lektury czwartego tomu przyg�d nastoletniego czarodzieja. Nowe wydanie ksi��ki o najs�ynniejszym czarodzieju �wiata r�ni si� od poprzednich nie tylko ok�adk�, ale i wn�trzem � po raz pierwszy na pocz�tku ka�dego tomu pojawi si� mapka Hogwartu i okolic, a pocz�tki rozdzia��w ozdobione b�d� specjalnymi gwiazdkami.",
                Publisher = "Media Rodzina",
                Year = 2000,
                NumberOfPages = 768,
                Count = 3
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 5,
                Name = "Harry Potter i Zakon Feniksa",
                Author = "J.K. Rowling",
                Genre = "Literatura m�odzie�owa",
                ShortDescription = "Harry zn�w sp�dza nudne, samotne wakacje w domu Dursley�w. Czeka go pi�ty rok nauki w Hogwarcie i chcia�by jak najszybciej spotka� si� ze swoimi najlepszymi przyjaci�mi, Ronem i Hermion�. Ci jednak wyra�nie go zaniedbuj�.",
                LongDescription = "Harry zn�w sp�dza nudne, samotne wakacje w domu Dursley�w. Czeka go pi�ty rok nauki w Hogwarcie i chcia�by jak najszybciej spotka� si� ze swoimi najlepszymi przyjaci�mi, Ronem i Hermion�. Ci jednak wyra�nie go zaniedbuj�. Gdy Harry ma ju� do�� wszystkiego i postanawia zmieni� swoj� niezno�n� sytuacj�, sprawy przyjmuj� ca�kiem nieoczekiwany obr�t. Wygl�da na to,�e nowy rok nauki w Hogwarcie b�dzie bardzo dramatyczny.Po raz pierwszy w �yciu Harry poczuje si� tam nie jak w domu, tylko� wi�zieniu, i to nie za spraw� przywr�conego do �ycia Lorda Voldemorta. Nowe wydanie ksi��ki o najs�ynniejszym czarodzieju �wiata r�ni si� od poprzednich nie tylko ok�adk�, ale i wn�trzem � po raz pierwszy na pocz�tku ka�dego tomu pojawi si� mapka Hogwartu i okolic, a pocz�tki rozdzia��w ozdobione b�d� specjalnymi gwiazdkami.",
                Publisher = "Media Rodzina",
                Year = 2003,
                NumberOfPages = 960,
                Count = 3
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 6,
                Name = "Harry Potter i Ksi��� P�krwi",
                Author = "J.K. Rowling",
                Genre = "Literatura m�odzie�owa",
                ShortDescription = "Po nieudanej pr�bie przechwycenia przepowiedni Lord Voldemort jest got�w uczyni� wszystko, by zaw�adn�� �wiatem czarodziej�w. Organizuje tajemny zamach na swego przeciwnika, a narz�dziem w jego r�ku staje si� jeden z uczni�w. Czy jego plan si� powiedzie?",
                LongDescription = "Po nieudanej pr�bie przechwycenia przepowiedni Lord Voldemort jest got�w uczyni� wszystko, by zaw�adn�� �wiatem czarodziej�w. Organizuje tajemny zamach na swego przeciwnika, a narz�dziem w jego r�ku staje si� jeden z uczni�w. Czy jego plan si� powiedzie? Sz�sta cz�� przyg�d Harry�ego Pottera przynosi cenne informacje o matce Voldemorta, jego dzieci�stwie oraz pocz�tkach kariery m�odego Toma Riddle�a, kt�re rzuc� nowe �wiat�o na sylwetk� g��wnego antagonisty Pottera. Na czym polega sekret nadprzyrodzonej mocy Czarnego Pana ? Jaki jest cel tajemniczych i niebezpiecznych wypraw Dumbledore�a ? I wreszcie, kto jest tytu�owym Ksi�ciem P�krwi i jak� misj� ma on do spe�nienia? Nowe wydanie ksi��ki o najs�ynniejszym czarodzieju �wiata r�ni si� od poprzednich nie tylko ok�adk�, ale i wn�trzem � po raz pierwszy na pocz�tku ka�dego tomu pojawi si� mapka Hogwartu i okolic, a pocz�tki rozdzia��w ozdobione b�d� specjalnymi gwiazdkami.",
                Publisher = "Media Rodzina",
                Year = 2005,
                NumberOfPages = 704,
                Count = 3
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 7,
                Name = "Harry Potter i Insygnia �mierci",
                Author = "J.K. Rowling",
                Genre = "Literatura m�odzie�owa",
                ShortDescription = "Po �mierci Dumbledore'a Zakon Feniksa wzmaga swoj� dzia�alno��, pr�buj�c przeciwstawi� si� coraz pot�niejszym si�om �miercio�erc�w. Harry wraz z przyjaci�mi nie wraca do Hogwartu, tylko wyrusza z misj� znalezienia sposobu na pokonanie Voldemorta.",
                LongDescription = "Po �mierci Dumbledore'a Zakon Feniksa wzmaga swoj� dzia�alno��, pr�buj�c przeciwstawi� si� coraz pot�niejszym si�om �miercio�erc�w. Harry wraz z przyjaci�mi nie wraca do Hogwartu, tylko wyrusza z misj� znalezienia sposobu na pokonanie Voldemorta. Wyprawa ta pe�na niepewno�ci i zw�tpienia naje�ona jest niebezpiecze�stwami, a co gorsza nikt nie wie, czy zako�czy si� sukcesem i czy wszyscy dotrwaj� do jej ko�ca. Dlaczego Dumbledore nie pozostawi� Harry`emu czytelnych wskaz�wek ? Czy przesz�o�� nie�yj�cego dyrektora kryje jakie� niezwyk�e tajemnice ? Jak� rol� odegra Snape przy boku Voldemorta ? Czy Harry`emu uda si� dotrze� do najwa�niejszych miejsc i fakt�w dotycz�cych jego rodziny? Si�dmy tom przyniesie odpowiedzi na wszystkie istotne dla potteromaniak�w pytania. Nowe wydanie ksi��ki o najs�ynniejszym czarodzieju �wiata r�ni si� od poprzednich nie tylko ok�adk�, ale i wn�trzem � po raz pierwszy na pocz�tku ka�dego tomu pojawi si� mapka Hogwartu i okolic, a pocz�tki rozdzia��w ozdobione b�d� specjalnymi gwiazdkami.",
                Publisher = "Media Rodzina",
                Year = 2007,
                NumberOfPages = 782,
                Count = 3
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 8,
                Name = "1984",
                Author = "George Orwell",
                Genre = "Literatura pi�kna",
                ShortDescription = "Najwa�niejsz� i chyba najs�ynniejsz� ksi��k� Orwella jest 1984. Ta ponura antyutopia rozgrywa si� w rz�dzonym przez totalitarny re�im Wielkiego Brata Londynie, a ca�y �wiat podzielony jest na trzy walcz�ce ze sob� bloki pa�stw-supermocarstw.",
                LongDescription = "Najwa�niejsz� i chyba najs�ynniejsz� ksi��k� Orwella jest 1984. Ta ponura antyutopia rozgrywa si� w rz�dzonym przez totalitarny re�im Wielkiego Brata Londynie, a ca�y �wiat podzielony jest na trzy walcz�ce ze sob� bloki pa�stw-supermocarstw. Cho� mo�e to wcale nieprawda. Bowiem w �wiecie 1984 s�owa straci�y ju� swoje znaczenie, a dwa plus dwa nie musi ju� r�wna� si� cztery. Wszak g��wny bohater powie�ci Winston Smith pracuje w Ministerstwie Prawdy, kt�re zajmuje si� manipulacj�, propagand� i dezinformacj�. A dzia�a jeszcze Ministerstwo Pokoju, kt�re zajmuje si� Wojn�. Ministerstwo Mi�o�ci prze�ladowaniem obywateli, utrzymywaniem przy pomocy si�y porz�dku, egzekucjami i torturami. A Ministerstwo Obfito�ci � rozdawaniem g�odowych racji dla mot�ochu. Pewnie nie wszystkie cechy tego Orwellowskiego systemu dostrzegamy w naszej rzeczywisto�ci, ale wiele z nich ci�gle si� nam we wsp�czesnym �wiecie objawia.I nie chodzi tylko o P�nocn� Kore�! Musicie kupi� t� ksi��k�, bo mo�e ju� nied�ugo � jak za czas�w PRL � b�dzie zakazana!",
                Publisher = "Vis-�-Vis/Etiuda",
                Year = 1949,
                NumberOfPages = 240,
                Count = 3
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 9,
                Name = "Dziewczyna z poci�gu",
                Author = "Paula Hawkins",
                Genre = "Krymina�, sensacja, thriller",
                ShortDescription = "�ycie Rachel wydaje si� zwyczajne. Ka�dego dnia kobieta jedzie do pracy tym samym poci�giem. Ka�dego dnia poci�g zatrzymuje si� w tych samych miejscach. Jest w�r�d nich semafor przed pewnym szeregiem domostw.",
                LongDescription = "�ycie Rachel wydaje si� zwyczajne. Ka�dego dnia kobieta jedzie do pracy tym samym poci�giem. Ka�dego dnia poci�g zatrzymuje si� w tych samych miejscach. Jest w�r�d nich semafor przed pewnym szeregiem domostw.Rachel ka�dego ranka widuje te same postaci.Sprawia to, �e kobiecie wydaje si�, �e zna ludzi, kt�rych �ycie podgl�da z okien poci�gu.Te kilka minut dziennie styczno�ci sprawia, �e Rachel uwa�a, �e prowadz� oni doskona�e �ycie.Marzy o tym, by r�wnie� jej �ywot by� taki, jak znajomych - nieznajomych zza okna. Kt�rego� dnia widzi co� wstrz�saj�cego.W zasadzie nie jest pewna, co zobaczy�a, gdy� poci�g ruszy�.Co zrobi Rachel ? Czy alkoholiczka jest wiarygodnym �wiadkiem ? Czy wykorzysta mo�liwo�� pojawienia si� w �yciu os�b, kt�re widywa�a jedynie przez okno poci�gu ? Posta� g��wnej bohaterki jest do�� kontrowersyjna i opinie Czytelnik�w s� podzielone.Przekonaj si� sam i oce�, czy ksi��ka, kt�r� polecaj� wielkie nazwiska w �wiecie sensacji i krymina�u spodoba si� r�wnie� Tobie!",
                Publisher = "�wiat Ksi��ki",
                Year = 2015,
                NumberOfPages = 328,
                Count = 3
            });
        }
    }
}