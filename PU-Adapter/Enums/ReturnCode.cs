using System.ComponentModel.DataAnnotations;

namespace Kentor.PU_Adapter.Enums
{
    public enum ReturnCode
    {
        [Display(Description = "Tjänsten utförd")]
        Tjänsten_utförd = 0000,

        [Display(Description = "Sökt person saknas i registren")]
        Sökt_person_saknas_i_registren = 0001,

        [Display(Description = "Sökt person har skyddad identitet och är därför anonymiserad")]
        Sökt_person_har_skyddad_identitet_och_är_därför_anonymiserad = 0002,

        [Display(Description = "Personen utflyttad och saknas i externt system")]
        Personen_utflyttad_och_saknas_i_externt_system = 0003,

        [Display(Description = "Tekniskt problem vid hämtning från externt system")]
        Tekniskt_problem_vid_hämtning_från_externt_system = 0019,

        [Display(Description = "Felaktigt format på inmatat personnummer")]
        Felaktigt_format_på_inmatat_personnummer = 0020,

        [Display(Description = "Felaktigt format på inmatat reservnummer")]
        Felaktigt_format_på_inmatat_reservnummer = 0101,

        [Display(Description = "Reservnummer saknas i registren")]
        Reservnummer_saknas_i_registren = 0102,

        [Display(Description = "Reservnummerserien slut")]
        Reservnummerserien_slut = 0108,

        [Display(Description = "Födelsedatum felaktigt")]
        Födelsedatum_felaktigt = 0110,

        [Display(Description = "Län felaktigt")]
        Län_felaktigt = 0112,

        [Display(Description = "Kommun felaktig")]
        Kommun_felaktig = 0113,

        [Display(Description = "Församling felaktig")]
        Församling_felaktig = 0114,

        [Display(Description = "Felaktigt namn")]
        Felaktigt_namn = 0115,

        [Display(Description = "Postnummer felaktigt")]
        Postnummer_felaktigt = 0117,

        [Display(Description = "Kön felaktigt")]
        Kön_felaktigt = 0127,

        [Display(Description = "Personnummer-från felaktigt")]
        Personnummer_från_felaktigt = 0150,

        [Display(Description = "Personnummer-till felaktigt")]
        Personnummer_till_felaktigt = 0151,

        [Display(Description = "Inga id-kopplingar finns")]
        Inga_id_kopplingar_finns = 0152,

        [Display(Description = "Personnummer-från saknas i registren")]
        Personnummer_från_saknas_i_registren = 0153,

        [Display(Description = "Personnummer-till saknas i registren")]
        Personnummer_till_saknas_i_registren = 0154,

        [Display(Description = "Otillåten koppling av två personnummer")]
        Otillåten_koppling_av_två_personnummer = 0155,

        [Display(Description = "Otillåten koppling av två personnummer via reservnummer")]
        Otillåten_koppling_av_två_personnummer_via_reservnummer = 0156,

        [Display(Description = "Tjänsten måste anropas med ett reservnummer")]
        Tjänsten_måste_anropas_med_ett_reservnummer = 0157,

        [Display(Description = "Ogiltigt datum")]
        Ogiltigt_datum = 0158,

        [Display(Description = "Historikinformation finns ej för angivet datum")]
        Historikinformation_finns_ej_för_angivet_datum = 0159,

        [Display(Description = "Historikinformation finns ej för utomlänare/reservnummer")]
        Historikinformation_finns_ej_för_utomlänare_reservnummer = 0160,

        [Display(Description = "Programfel i tjänsten")]
        Programfel_i_tjänsten = 0300,

        [Display(Description = "Databasfel")]
        Databasfel = 0301,

        [Display(Description = "Ogiltlig single-signon-biljett")]
        Ogiltlig_single_signon_biljett = 0305,

        [Display(Description = "Användaren saknar behörighet")]
        Användaren_saknar_behörighet = 0306,

        [Display(Description = "Tekniskt fel i tjänsten")]
        Tekniskt_fel_i_tjänsten = 0307,

        [Display(Description = "Databasfel eller samtidig uppdatering av annan användare")]
        Databasfel_eller_samtidig_uppdatering_av_annan_användare = 0308,

        [Display(Description = "Tjänsten har utgått")]
        Tjänsten_har_utgått = 9999,
    }
}