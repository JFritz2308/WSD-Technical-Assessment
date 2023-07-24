namespace WSD_Technical_Assessment
{
    public class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            //  Faster taps, slower time DATA
            int[] testBottles = { 300, 200, 1000, 500 };
            int testTaps = 3;
            int testWalk = 0;
            int[] testTaps3 = { 200, 100 }; //  Increase Tap 2 from 100 ml/s -> 150 ml/s to see time increase by 1 second

            //Console.WriteLine(p.Water(testBottles, testTaps));
            //Console.WriteLine(p.Water2(testBottles, testTaps, testWalk));
            Console.WriteLine(p.Water3(testBottles, testTaps3, testWalk));
        }


        private double Water(int[] arrBottles, int intTaps)
        {
            //  Input Validition
            try
            {
                foreach (int bottle in arrBottles)
                    if (bottle <= 0)
                        throw new ArithmeticException();

                if (intTaps <= 0)
                    throw new ArithmeticException();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Input! Please ensure:" +
                    "\nThe queue of people is inputted as an array of non-zero postive integers values representing their bottle capacity (ml)" +
                    "\nThe number of taps is inputted as an non-zero positive integer value");
                return -1;
            }


            double[] arrTime = new double[intTaps]; //  Time taken at each tap

            foreach (int bottle in arrBottles)
            {
                arrTime[0] += (double)bottle / 100; //  Adds time to available tap
                if (arrTime[0] > arrTime[1])    //  Only sorts if current tap is not longer available (has the lowest time)
                    Array.Sort(arrTime);
            }

            return arrTime.Max();
        }


        private double Water2(int[] arrBottles, int intTaps, int intWalk)
        {
            //  Input Validition
            try
            {
                foreach (int bottle in arrBottles)
                    if (bottle <= 0)
                        throw new ArithmeticException();

                if (intTaps <= 0)
                    throw new ArithmeticException();

                if (intWalk < 0)
                    throw new ArithmeticException();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Input! Please ensure:" +
                    "\nThe queue of people is inputted as an array of non-zero postive integers values representing their bottle capacity (ml)" +
                    "\nThe number of taps is inputted as an non-zero positive integer value" +
                    "\nThe time to walk to the tap is inputted as a fixed non-negative integer value (s)");
                return -1;
            }


            double[] arrTime = new double[intTaps]; //  Time taken at each tap

            foreach (int bottle in arrBottles)
            {
                arrTime[0] += intWalk + (double)bottle / 100; //  Assumes people start in the queue and must walk to the tap
                if (arrTime[0] > arrTime[1])    //  Only sorts if current tap is not longer available (has the lowest time)
                    Array.Sort(arrTime);
            }

            return arrTime.Max();
        }


        private double Water3(int[] arrBottles, int[] arrTaps, int intWalk)
        {
            //  Input Validition
            try
            {
                foreach (int bottle in arrBottles)
                    if (bottle <= 0)
                        throw new ArithmeticException();

                foreach (int tap in arrTaps)
                    if (tap <= 0)
                        throw new ArithmeticException();

                if (intWalk < 0)
                    throw new ArithmeticException();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Input! Please ensure:" +
                    "\nThe queue of people is inputted as an array of non-zero postive integers values representing their bottle capacity (ml)" +
                    "\nThe number of taps is inputted as an array of non-zero positive integer values representing their rate of flows (ml/s)" +
                    "\nThe time to walk to the tap is inputted as a fixed non-negative integer value (s)");
                return -1;
            }


            double[] arrTime = new double[arrTaps.Count()]; //  Time taken at each tap

            foreach (int bottle in arrBottles)
            {
                arrTime[0] += intWalk + (double)bottle / arrTaps[0]; //  Assumes people start in the queue and must walk to the tap
                if (arrTime[0] > arrTime[1])    //  Only sorts if current tap is not longer available (has the lowest time)
                    Array.Sort(arrTime, arrTaps);
            }

            return arrTime.Max();
        }
    }
}