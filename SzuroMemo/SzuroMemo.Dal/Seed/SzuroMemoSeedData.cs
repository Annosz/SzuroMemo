using System;
using SzuroMemo.Dal.Entities;

namespace SzuroMemo.Dal.Seed
{
    public class SzuroMemoSeedData
    {
        public Screening[] Screenings { get; set; } =
        {
            new Screening { Name = "Nőgyógyászati rákszűrés", ReferralNeeded = false, Description = "A női nemi szervek harmadik leggyakoribb rosszindulatú megbetegedése a méhnyakrák. Magyarországon évente csaknem hatszáz nő hal meg e súlyos megbetegedésben, mely a női nemi szervi rákok 10-12%-át teszi ki. Bár az utóbbi évtizedben előfordulási gyakorisága csökken, a veszélyeztetett életkor azonban sajnos az egyre fiatalabb korosztály felé tolódik el."},
            new Screening { Name = "Tüdőszűrés", ReferralNeeded = false, Description = "A korai, tünetmentes szakban kiemelt nagyszámú, köztük több mint félezer fertőző beteg időben elkezdett kezelése miatt még mindig jelentős népegészségügyi tényező a tüdőszűrő. Részletek: http://www.webbeteg.hu/cikkek/legzoszervi_betegseg/4850/a-tudoszures-szabalyozasa"},
            new Screening { Name = "HIV szűrés", ReferralNeeded = false, Description = "Az AIDS betegség eredményes kezelése szempontjából döntő fontosságú a mielőbbi diagnózis, amely a vérben lévő HIV vírusok, pontosabban az ellenük a szervezet által termelt ellenanyagok kimutatásán alapul."},
            new Screening { Name = "Szemészeti szűrővizsgálat", ReferralNeeded = false, Description = "Iskolásként néhány hét alatt kiderülhet, hogy a gyermekünk nem jól lát, de az is lehet, hogy csak hónapok múltán kezdünk gyanakodni, hogy a tanulási gondok hátterében látási problémák állhatnak. Ma már csecsemőkortól ajánlott megjelenni szemészeti szűrővizsgálaton, ahol nem csak a távol- vagy a közellátási nehézségekre derülhet fény. Számos eltérés pedig csak akkor kezelhető, ha a lehető legkisebb korban felfedezik. Részletek: http://www.webbeteg.hu/cikkek/szem_betegsegei/5663/gyermekkortol-fontos-a-szemeszeti-szures"},
            new Screening { Name = "Fogászati szűrés", ReferralNeeded = false, Description = "Ha semmilyen komoly gond nincs – fájdalom, egyéb elváltozás a szájban –, akkor minimum évente egyszer érdemes bejelentkezni a fogorvoshoz kontrollra. Hiszen minden betegség – így a fogászati jellegűek is – a megelőzéssel, illetve az időben felállított diagnózissal kezelhető a leghatékonyabban."},
            new Screening { Name = "Pajzsmirigyszűrés", ReferralNeeded = true, Description = "A szervi eltéréseket, különböző fájdalmakat a legtöbb esetben magunk is felismerjük, így könnyen fordulunk a megfelelő szakorvoshoz. A hormonális rendszerben keletkezett változások azonban olyan szerteágazó tüneteket okozhatnak, melyek forrása sok esetben nem egyértelmű. A tünetek hátterében álló okok feltárása több módon történhet."},
            new Screening { Name = "Vesekőszűrés", ReferralNeeded = false, Description = "A veseköveknek többféle típusa létezik, ezek közül a leggyakoribbak a kálciumból és oxalátból álló kövek. Ezek kialakulása leginkább a táplálkozással és a napi folyadékbevitel mennyiségével függ össze, míg a ritkábban előforduló kövek esetén anyagcsere-betegség vagy fertőzések állhatnak a kő kialakulásának hátterében. A vesekövek többsége – 70-80 százalékuk – spontán módon, a vizelettel együtt ki tud ürülni, ha pedig ez nem történik meg, gyógynövénykészítmények alkalmazására, ultrahangos vagy lézeres beavatkozásra van szükség. Súlyosabb esetekben a bőrön át bevezetett, kamerával rendelkező fél-egy centiméteres eszközzel úgynevezett perkután műtétet vagy nagyon ritkán nyílt műtétet kell végezni."}
        };

        public Hospital[] Hospitals { get; set; } =
        {
            new Hospital { Name = "Honvédkórház", Address = new Address { ZipCode = 1134, Settlement = "Budapest XIII.", StreetAddress = "Róbert Károly körút 44."}, PictureUrl = "http://img2.hvg.hu/image.aspx?id=7abb8ea3-baf3-4e28-b44d-9e5cdd6f8f12&view=da658e97-86c0-40f3-acd3-b0a850f32c30"},
            new Hospital { Name = "Heim Pál Gyermekkórház", Address = new Address { ZipCode = 1131, Settlement = "Budapest XIII.", StreetAddress = "Madarász Viktor utca 22-24."}, PictureUrl = "https://13.kerulet.ittlakunk.hu/files/ittlakunk/upload/company/38/madarasz.jpg"},
            new Hospital { Name = "Szent János Kórház", Address = new Address { ZipCode = 1125, Settlement = "Budapest XII.", StreetAddress = "Diós árok 1-3."}, PictureUrl = "https://24.p3k.hu/app/uploads/2013/07/Janos-korhaz.jpg"}
        };

        public OccasionSeedDto[] Occasions { get; set; } =
        {
            new OccasionSeedDto { StartTime = new DateTime(2018, 5, 19, 8, 0, 0), EndTime = new DateTime(2018, 5, 19, 18, 0, 0), Description = "Bejelentkezés köteles a kórház központi telefonszámán!", Screening = "Nőgyógyászati rákszűrés", Hospital = "Honvédkórház"},
            new OccasionSeedDto { StartTime = new DateTime(2018, 5, 21, 8, 0, 0), EndTime = new DateTime(2018, 5, 21, 18, 0, 0), Description = "Bejelentkezés köteles", Screening  = "Szemészeti szűrővizsgálat", Hospital = "Heim Pál Gyermekkórház"},
            new OccasionSeedDto { StartTime = new DateTime(2018, 5, 22, 8, 0, 0), EndTime = new DateTime(2018, 5, 22, 14, 30, 0), Description = "A Szent János kórház megközelítésére a villamos ajánlott, mivel parkolóhelyet nem tudunk biztosítani. Kérjük, érkezését jelentse be előre a portán a 06 1 458 4500 telefonszámon, és próbálja a 11:00-13:00 idősávra időzíteni!", Screening = "Pajzsmirigyszűrés", Hospital  = "Szent János Kórház"},
            new OccasionSeedDto { StartTime = new DateTime(2018, 5, 20, 8, 0, 0), EndTime = new DateTime(2018, 5, 20, 18, 0, 0), Description = "Bejelentkezés köteles a kórház központi telefonszámán!", Screening = "Nőgyógyászati rákszűrés", Hospital = "Honvédkórház"},
            new OccasionSeedDto { StartTime = new DateTime(2018, 5, 24, 8, 0, 0), EndTime = new DateTime(2018, 5, 24, 20, 0, 0), Description = "Bejelentkezés köteles a kórház központi telefonszámán! A szűrés időpontjában ingyenes vérvételi és -vizsgálati lehetőség is adott.", Screening = "Pajzsmirigyszűrés", Hospital = "Honvédkórház"},
        };

        /*public User[] Users { get; set; } =
        {
            //new User {Name = "Adam"},
            new User {Name = "Bob"}
        };

        public MedicalRecord[] MedicalRecords { get; set; } =
        {
            //new MedicalRecord {Male = true, Weight = 65, Height = 186},
            new MedicalRecord {Male = true, Weight = 87, Height = 195}
        };

        public LastScreening[] LastScreenings { get; set; } =
        {
            new LastScreening { Time = new DateTime(2018, 3, 11)},
            new LastScreening { Time = new DateTime(2018, 2, 4)},
            new LastScreening { Time = new DateTime(2018, 3, 28)}
        };

        public Registration[] Registrations { get; set; } =
        {
            new Registration { Arrival = new DateTime(2018, 5, 4, 14, 30, 0)},
            new Registration { Arrival = new DateTime(2018, 5, 4, 14, 0, 0)},
            new Registration { Arrival = new DateTime(2018, 5, 4, 9, 0, 0)}
        };*/

        public class OccasionSeedDto
        {
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string Description { get; set; }
            public string Hospital { get; set; }
            public string Screening { get; set; }
        }
    }
}
