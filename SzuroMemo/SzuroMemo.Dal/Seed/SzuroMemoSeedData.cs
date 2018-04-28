using SzuroMemo.Dal.Entities;

namespace SzuroMemo.Dal.Seed
{
    public class SzuroMemoSeedData
    {
        public Screening[] Screenings { get; set; } =
        {
            new Screening { Name = "Nőgyógyászati rákszűrés", ReferralNeeded = false, Description = "A női nemi szervek harmadik leggyakoribb rosszindulatú megbetegedése a méhnyakrák. Magyarországon évente csaknem hatszáz nő hal meg e súlyos megbetegedésben, mely a női nemi szervi rákok 10-12%-át teszi ki. Bár az utóbbi évtizedben előfordulási gyakorisága csökken, a veszélyeztetett életkor azonban sajnos az egyre fiatalabb korosztály felé tolódik el."},
            new Screening { Name = "Tüdőszűrés", ReferralNeeded = false, Description = "A korai, tünetmentes szakban kiemelt nagyszámú, köztük több mint félezer fertőző beteg időben elkezdett kezelése miatt még mindig jelentős népegészségügyi tényező a tüdőszűrő. Részletek: http://www.webbeteg.hu/cikkek/legzoszervi_betegseg/4850/a-tudoszures-szabalyozasa"},
            new Screening { Name = "HIV szűrés", ReferralNeeded = false, Description = "Az AIDS betegség eredményes kezelése szempontjából döntő fontosságú a mielőbbi diagnózis, amely a vérben lévő HIV vírusok, pontosabban az ellenük a szervezet által termelt ellenanyagok kimutatásán alapul."}
        };
    }
}
