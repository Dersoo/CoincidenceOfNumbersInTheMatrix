namespace ArrayGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Testing arrays
            byte[,] testArrayWithHorizontalCoincidences1 = new byte[9, 9] {
                                                    {1, 2, 2, 2, 2, 7, 8, 9, 3 },
                                                    {1, 0, 2, 0, 2, 7, 8, 9, 3 },
                                                    {1, 3, 2, 0, 2, 7, 8, 9, 3 },
                                                    {1, 2, 1, 0, 2, 7, 8, 9, 3 },
                                                    {1, 1, 2, 0, 1, 1, 1, 1, 3 },
                                                    {1, 0, 2, 0, 2, 7, 8, 9, 3 },
                                                    {1, 0, 0, 0, 2, 7, 8, 9, 3 },
                                                    {1, 2, 1, 0, 2, 7, 8, 9, 3 },
                                                    {1, 2, 3, 0, 2, 7, 8, 9, 3 }
                                               };
            byte[,] testArrayWithHorizontalCoincidences2 = new byte[9, 9] {
                                                    {1, 2, 2, 2, 2, 7, 8, 9, 3 },
                                                    {1, 0, 2, 0, 2, 7, 8, 9, 3 },
                                                    {1, 3, 2, 0, 2, 7, 8, 9, 3 },
                                                    {1, 2, 1, 0, 2, 7, 8, 9, 3 },
                                                    {1, 1, 2, 0, 1, 1, 1, 1, 3 },
                                                    {1, 0, 2, 0, 2, 7, 8, 9, 3 },
                                                    {1, 0, 0, 0, 2, 7, 8, 9, 3 },
                                                    {1, 2, 1, 0, 2, 7, 8, 9, 3 },
                                                    {1, 1, 3, 0, 2, 7, 2, 2, 2 }
                                                };

            byte[,] testArrayWithVerticalCoincidences1 = new byte[9, 9] {
                                                    {1, 2, 1, 2, 0, 7, 8, 9, 3 },
                                                    {1, 0, 2, 0, 2, 7, 8, 9, 3 },
                                                    {1, 3, 2, 0, 2, 7, 8, 9, 3 },
                                                    {1, 2, 1, 0, 2, 7, 8, 9, 3 },
                                                    {1, 1, 2, 0, 1, 2, 1, 2, 3 },
                                                    {1, 0, 2, 0, 2, 7, 8, 9, 3 },
                                                    {1, 0, 3, 0, 2, 7, 8, 9, 3 },
                                                    {1, 2, 1, 0, 2, 7, 8, 9, 3 },
                                                    {1, 2, 3, 0, 2, 7, 8, 9, 3 }
                                               };
            byte[,] testArrayWithVerticalCoincidences2 = new byte[9, 9] {
                                                    {1, 2, 1, 2, 0, 7, 8, 9, 0 },
                                                    {1, 0, 2, 0, 2, 7, 8, 9, 3 },
                                                    {1, 3, 2, 0, 2, 7, 8, 9, 3 },
                                                    {2, 2, 1, 1, 2, 7, 8, 9, 1 },
                                                    {1, 1, 2, 0, 1, 2, 1, 2, 3 },
                                                    {3, 0, 2, 0, 2, 7, 8, 9, 2 },
                                                    {1, 0, 3, 0, 2, 7, 8, 9, 3 },
                                                    {0, 2, 1, 0, 2, 7, 8, 9, 3 },
                                                    {1, 2, 3, 2, 2, 7, 8, 9, 3 }
                                                };
            byte[,] testArrayWithHorizontalAndVerticalCoincidences2 = new byte[9, 9] {
                                                    {1, 2, 1, 2, 0, 7, 8, 9, 0 },
                                                    {1, 0, 0, 0, 2, 7, 8, 0, 3 },
                                                    {1, 3, 2, 0, 2, 2, 1, 9, 3 },
                                                    {2, 2, 1, 1, 2, 7, 8, 9, 1 },
                                                    {1, 1, 2, 0, 1, 2, 1, 2, 3 },
                                                    {3, 0, 2, 2, 2, 7, 8, 9, 2 },
                                                    {1, 0, 3, 0, 2, 1, 1, 1, 3 },
                                                    {0, 2, 1, 1, 2, 7, 8, 2, 3 },
                                                    {1, 2, 3, 2, 2, 7, 8, 9, 3 }
                                                };
            #endregion

            /*Test for horizontal coincidences:*/
            //Matrix m1 = new Matrix(9, 9, 0, 3, 3, testArrayWithHorizontalCoincidences1);

            //m1.SearchForHorizontalCoincidences();
            //m1.DisplayMatrix();

            /*Test for vertical coincidences:*/
            //Matrix m2 = new Matrix(9, 9, 0, 3, 3, testArrayWithVerticalCoincidences2);

            //m2.SearchForVerticalCoincidences();
            //m2.DisplayMatrix();

            /*Common test:*/
            Matrix m3 = new Matrix(9, 9, 0, 3, 3, testArrayWithHorizontalAndVerticalCoincidences2);

            m3.DisplayMatrix();
            m3.SearchForCoincidences();
        }
    }
}