namespace InnoThink.Domain.Constancy
{
    public enum GenderType
    {
        Male,
        Female
    }

    public enum AgeRangType
    {
        Under10,
        Be11_17,
        Be18_25,
        Be26_30,
        Be31_40,//4
        Be41_50,//5
        Be51_60,//6
        Over61,
        Be11_20,//8
        Be21_30,//9
    }

    public enum EduType
    {
        Kindergarten,//幼稚園
        Elementary,//國小
        JuniorHighSchool,//國中
        SeniorHighSchool,//高中
        University,//大學
        Master,//碩士
        Doctor//博士
    }

    public enum SalaryType
    {
        Under10k,
        Under20k,
        Under30k,
        Under40k,
        Under50k,
        Under60k,
        Under70k,
        Over70k,
    }

    public enum ScenarioType
    {
        FirstTime,
        SecondTime,
    }
}