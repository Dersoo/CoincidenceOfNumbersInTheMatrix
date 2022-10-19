using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArrayGame
{
    class Matrix
    {
        private byte[,] _matrix;
        private byte _minValue;
        private byte _maxValue;
        private byte _minimumSequence;
        Random randomNumber = new Random();

        private void FillTheMatrixRandomValuesInRange()
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    _matrix[i, j] = (byte) randomNumber.Next(_minValue, _maxValue + 1);
                }
            }
        }

        public Matrix() : this(9, 9, 0, 3, 3, null)
        {
        }

        public Matrix(byte rowsCount, byte columnsCount, byte minValue, byte maxValue, byte minimumSequence, byte[,]? customMatrix)
        {
            _matrix = new byte[rowsCount, columnsCount];
            _minValue = minValue;
            _maxValue = maxValue;
            _minimumSequence = minimumSequence;

            if (customMatrix != null)
            {
                _matrix = customMatrix;
            }
            else 
            {
                FillTheMatrixRandomValuesInRange();
            }
        }

        public void DisplayMatrix()
        {
            for (byte i = 0; i < _matrix.GetLength(0); i++)
            {
                for (byte j = 0; j < _matrix.GetLength(1); j++)
                {
                    Console.Write(_matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private void ShiwtTheColumnElementsDownForHorizontalCoincidences(byte rowIndex, byte columnIndex)
        {
            for (byte i = rowIndex; i >= 1; i--)
            {
                _matrix[i, columnIndex] = _matrix[i - 1, columnIndex];
            }

            _matrix[0, columnIndex] = (byte)randomNumber.Next(_minValue, _maxValue + 1);
        }

        private void ShiwtTheColumnElementsDownForVerticalCoincidences(byte columnIndex, byte rowIndex, byte shiftIndex)
        {
            byte degreeOfShifts = (byte)(rowIndex / shiftIndex);

            for (byte i = (byte)(rowIndex + (shiftIndex - 1)); i >= rowIndex; i--)
            {
                if (i == (shiftIndex - 1))
                {
                    break;
                }

                if (degreeOfShifts > 1)
                {
                    for (byte k = 1; k <= degreeOfShifts; k++)
                    {
                        _matrix[i + shiftIndex - (shiftIndex * k), columnIndex] = _matrix[i - (shiftIndex * k), columnIndex];
                    }
                }
                else
                {
                    _matrix[i, columnIndex] = _matrix[i - shiftIndex, columnIndex];
                }
            }

            for (byte j = 0; j <= (shiftIndex - 1); j++)
            {
                _matrix[j, columnIndex] = (byte)randomNumber.Next(_minValue, _maxValue + 1);
            }
        }

        public bool SearchForHorizontalCoincidences()
        {
            byte countOfCoincidences = 1;
            bool wereTransformationsInIteration = false;
            bool wereTransformationsInMethod = false;

            do
            {
                wereTransformationsInIteration = false;

                for (byte i = 0; i < _matrix.GetLength(0); i++)
                {
                    for (byte j = 0; j < _matrix.GetLength(1); j++)
                    {
                        for (byte n = (byte)(j + 1); n < _matrix.GetLength(1); n++)
                        {
                            if (_matrix[i, j] == _matrix[i, n])
                            {
                                countOfCoincidences++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (countOfCoincidences == _minimumSequence ||
                            countOfCoincidences > _minimumSequence)
                        {
                            wereTransformationsInIteration = true;

                            for (byte k = j; k <= (j + (countOfCoincidences - 1)); k++)
                            {
                                ShiwtTheColumnElementsDownForHorizontalCoincidences(i, k);
                            }

                            j += (byte)(countOfCoincidences - 1);
                        }

                        countOfCoincidences = 1;
                    }

                    Console.WriteLine($"Line analysis number {i + 1} :");
                    Console.WriteLine();
                    DisplayMatrix();
                    Console.WriteLine();
                }

                if (wereTransformationsInIteration)
                {
                    wereTransformationsInMethod = true;
                }
            }
            while (wereTransformationsInIteration);

            return wereTransformationsInMethod;
        }

        public bool SearchForVerticalCoincidences()
        {
            byte countOfCoincidences = 1;
            bool wereTransformationsInIteration = false;
            bool wereTransformationsInMethod = false;

            do
            {
                wereTransformationsInIteration = false;

                for (byte i = 0; i < _matrix.GetLength(1); i++)
                {
                    for (byte j = 0; j < _matrix.GetLength(0); j++)
                    {
                        for (byte n = (byte)(j + 1); n < _matrix.GetLength(0); n++)
                        {
                            if (_matrix[j, i] == _matrix[n, i])
                            {
                                countOfCoincidences++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (countOfCoincidences == _minimumSequence ||
                            countOfCoincidences > _minimumSequence)
                        {
                            wereTransformationsInIteration = true;

                            ShiwtTheColumnElementsDownForVerticalCoincidences(i, j, countOfCoincidences);

                            j += (byte)(countOfCoincidences - 1);
                        }

                        countOfCoincidences = 1;
                    }

                    Console.WriteLine($"Column analysis number {i + 1} :");
                    Console.WriteLine();
                    DisplayMatrix();
                    Console.WriteLine();
                }

                if (wereTransformationsInIteration)
                {
                    wereTransformationsInMethod = true;
                }
            }
            while (wereTransformationsInIteration);

            return wereTransformationsInMethod;
        }

        public void SearchForCoincidences()
        {
            SearchForHorizontalCoincidences();

            while (true)
            {
                if (SearchForVerticalCoincidences())
                {
                    if (!SearchForHorizontalCoincidences())
                    {
                        break;
                    }
                }
                else 
                {
                    break;
                }
            }
        }
    }
}
