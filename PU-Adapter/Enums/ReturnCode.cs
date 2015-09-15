using System.ComponentModel;

namespace Kentor.PU_Adapter.Enums
{
    public enum ReturnCode
    {
        [Description("Tjänsten utförd")]
        Tjänsten_utförd = 0000,

        [Description("Sökt person saknas i registren")]
        Sökt_person_saknas_i_registren = 0001,

        [Description("Sökt person har skyddad identitet och är därför anonymiserad")]
        Sökt_person_har_skyddad_identitet_och_är_därför_anonymiserad = 0002,

        [Description("Personen utflyttad och saknas i externt system")]
        Personen_utflyttad_och_saknas_i_externt_system = 0003,

        [Description("Tekniskt problem vid hämtning från externt system")]
        Tekniskt_problem_vid_hämtning_från_externt_system = 0019,

        [Description("Felaktigt format på inmatat personnummer")]
        Felaktigt_format_på_inmatat_personnummer = 0020,

        [Description("Felaktigt format på inmatat reservnummer")]
        Felaktigt_format_på_inmatat_reservnummer = 0101,

        [Description("Reservnummer saknas i registren")]
        Reservnummer_saknas_i_registren = 0102,

        [Description("Reservnummerserien slut")]
        Reservnummerserien_slut = 0108,

        [Description("Födelsedatum felaktigt")]
        Födelsedatum_felaktigt = 0110,

        [Description("Län felaktigt")]
        Län_felaktigt = 0112,

        [Description("Kommun felaktig")]
        Kommun_felaktig = 0113,

        [Description("Församling felaktig")]
        Församling_felaktig = 0114,

        [Description("Felaktigt namn")]
        Felaktigt_namn = 0115,

        [Description("Postnummer felaktigt")]
        Postnummer_felaktigt = 0117,

        [Description("Kön felaktigt")]
        Kön_felaktigt = 0127,

        [Description("Personnummer-från felaktigt")]
        Personnummer_från_felaktigt = 0150,

        [Description("Personnummer-till felaktigt")]
        Personnummer_till_felaktigt = 0151,

        [Description("Inga id-kopplingar finns")]
        Inga_id_kopplingar_finns = 0152,

        [Description("Personnummer-från saknas i registren")]
        Personnummer_från_saknas_i_registren = 0153,

        [Description("Personnummer-till saknas i registren")]
        Personnummer_till_saknas_i_registren = 0154,

        [Description("Otillåten koppling av två personnummer")]
        Otillåten_koppling_av_två_personnummer = 0155,

        [Description("Otillåten koppling av två personnummer via reservnummer")]
        Otillåten_koppling_av_två_personnummer_via_reservnummer = 0156,

        [Description("Tjänsten måste anropas med ett reservnummer")]
        Tjänsten_måste_anropas_med_ett_reservnummer = 0157,

        [Description("Ogiltigt datum")]
        Ogiltigt_datum = 0158,

        [Description("Historikinformation finns ej för angivet datum")]
        Historikinformation_finns_ej_för_angivet_datum = 0159,

        [Description("Historikinformation finns ej för utomlänare/reservnummer")]
        Historikinformation_finns_ej_för_utomlänare_reservnummer = 0160,

        [Description("Programfel i tjänsten")]
        Programfel_i_tjänsten = 0300,

        [Description("Databasfel")]
        Databasfel = 0301,

        [Description("Ogiltlig single-signon-biljett")]
        Ogiltlig_single_signon_biljett = 0305,

        [Description("Användaren saknar behörighet")]
        Användaren_saknar_behörighet = 0306,

        [Description("Tekniskt fel i tjänsten")]
        Tekniskt_fel_i_tjänsten = 0307,

        [Description("Databasfel eller samtidig uppdatering av annan användare")]
        Databasfel_eller_samtidig_uppdatering_av_annan_användare = 0308,

        [Description("Tjänsten har utgått")]
        Tjänsten_har_utgått = 9999,
    }
}