using System;

namespace Hello
{
    class Program
    {
        static void Main(string[] args)
        {
            Salary person1 = new Salary("Kim Anna", 200000,2010);
            person1.NumWorkingDayOfMonth(5,2);
            person1.IncomeTaxSalary(6);
            Console.WriteLine(person1.ToString());
        }
    }

    /*3-нұсқа
            Жалақы класын құрыңыз. Класта келесідей өрістер болу керек:
             қызметкердің аты-жөні, жалақы сомасы (оклад), жұмысқа орналасу жылы,
             көтерме пайызы, табыс салығы, ай ішіндегі жалпы жұмыс күндерінің саны, 
             ай ішіндегі жұмысқа келген күндерінің саны, белгілі ай үшін есептелген жалақы 
             мөлшері (жұмыс істеген күндерінің санына байланысты) және ұсталған ақша мөлшерлері. 
             Келесі әдістерді жүзеге асырыңыз:
            1.	есептелген жалақы мөлшерін анықтау; ұсталған ақша мөлшерін анықтау;
            2.	қолға берілетін ақша көлемін және жұмыс өтілін анықтау.*/
    class Salary
    {
        public string FIO; // қызметкердің аты-жөні
        public int salarySum; // жалақы сомасы (оклад) 1 ай үшін шарт бойынша
        public int yearOfEmployment; // жұмысқа орналасу жылы
        private double _incomeTax; // табыс салығы
        private int _totalNumWorkingDaysOfMonth; // 1 ай ішіндегі жалпы жұмыс күндерінің саны
        private int _numWorkingDaysOfMonth; //1 ай ішіндегі жұмысқа келген күндерінің саны
        private int _salarySumMonth; // белгілі ай үшін есептелген жалақы мөлшері (жұмыс істеген күндерінің санына байланысты) 
        private double _amountsOfMoneyWithheld; // ұсталған ақша мөлшерлері

        public Salary(string name, int salarySumUser, int yearOfEmploymentUser)
        {
            FIO = name;
            salarySum = salarySumUser;
            yearOfEmployment = yearOfEmploymentUser;
        }
        
        public void IncomeTaxSalary(int nMonth)
        {
            //табыс салығын есептеу үшін, алдымен таза табыс мөлшерін анықтау қажет
            //табыс салығы=шарт бойынша жалақы - таза табыс
            //таза табыс= шарт бойынша жалақы-(ОПВ+ИПН)

            int salary = salarySum;
            double opv = salary * 0.1;
            double ipn = (salary - opv - 42500) * 0.1;
            double tazaTabys = salary - (opv + ipn);
            _salarySumMonth = salary;
            _incomeTax = opv + ipn;
            _amountsOfMoneyWithheld = salary-tazaTabys;
            if (nMonth>1)
            {
                tazaTabys = (salary - (opv + ipn)) * nMonth;
                _incomeTax = (opv + ipn)*nMonth;
                _amountsOfMoneyWithheld = salary*nMonth-tazaTabys;
                _salarySumMonth = salary*nMonth;
            }
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine($"Шарт бойынша 1 айдагы жалакы молшери: {salary}, табыс салыгы 1айдагы: {opv+ipn}, жане 1 айдагы таза табыс: {tazaTabys/nMonth}");
            Console.WriteLine($"Онда жалпы {nMonth}-ай ушин шарт бойынша жалакы молшери:{_salarySumMonth}," +
                              $"\n жане осы {nMonth}-ай ушин салык:{_incomeTax}, ал осы {nMonth}-айдагы таза табыс: {tazaTabys} ");
            Console.WriteLine("---------------------------------------------------------------");
        }

        public void NumWorkingDayOfMonth(int nWorkingWeek, int notWorkingDayOfMonth)
        {
            //1аптада n-рет келсе, барлық жұмыс күндерінің саны орташа есеппен, 4*n
            _totalNumWorkingDaysOfMonth = 4 * nWorkingWeek;
            _numWorkingDaysOfMonth = _totalNumWorkingDaysOfMonth - notWorkingDayOfMonth;
        }
        public override string ToString()
        {
            int n = _salarySumMonth / salarySum;
            return $"кызметкердин аты-жони: {FIO}, " +
                $"\n1 айдагы жалакы сомасы (оклад): {salarySum}," +
                $"\nжумыска орналасу жылы: {yearOfEmployment}," +
                $"\n1 айдагы табыс салыгы: {_incomeTax/n}, " +
                $"\n1 ай ишиндеги жалпы жумыс кундеринин саны: {_totalNumWorkingDaysOfMonth}, " +
                $"\n1 ай ишиндеги жумыска келген кундеринин саны: {_numWorkingDaysOfMonth}, " +
                $"\nберилген айлар ушин есептелген жалакы: {_salarySumMonth}" +
                $"\nжалпы усталган акша молшерлери: {_amountsOfMoneyWithheld}";
        }
    }
    
}