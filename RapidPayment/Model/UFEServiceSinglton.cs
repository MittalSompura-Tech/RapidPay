namespace RapidPayment.Model
{
    public sealed class UFEServiceSinglton
    {
        private static UFEServiceSinglton Instance = null;
        private static readonly object padlock = new object();


        private static double rnd;
        private static double lastfee=1.0;
        private static double curfee;
        private static double temp;


        public static double GetInstance()
        {
            //If the variable instance is null, then create the Singleton instance 
            //else return the already created singleton instance
            //This version is not thread safe
            //if (Instance == null)
            //{
                Instance = new UFEServiceSinglton();
            //}
            //Return the Singleton Instance
            curfee = lastfee * rnd;
            lastfee = curfee;
            return curfee;

        }
        private UFEServiceSinglton()
        {
            lab:
            rnd = new Random().Next(0,2);
            rnd=rnd * new Random().NextDouble();
            if (rnd==0)
            {
                goto lab;
            }
            //limit between 0 to 2

        }
        public double GetRandom()
        {
            return rnd;
        }
    }
}
