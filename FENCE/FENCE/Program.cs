using System;
using System.Collections.Generic;

namespace FENCE
{
    public class Program
    {
        //public static List<int> FenceHeights = new List<int> { 7, 1, 5, 9, 6, 7, 3 };
        //public static List<int> FenceHeights = new List<int> { 1, 4, 4, 4, 4, 1, 1 };
        public static List<int> FenceHeights = new List<int> { 1, 8, 2, 2 };
        static void Main(string[] args)
        {
            var aa = GetMaxArea(0, 3);
            Console.WriteLine("Hello World!");
        }

        public static int GetMaxArea(int leftIndex, int rightIndex)
        {
            int maxArea = 0;
            int middleIndex = (leftIndex + rightIndex) / 2;
            if(leftIndex == rightIndex)
            {
                return FenceHeights[leftIndex];
            }
            else if(leftIndex + 1 == rightIndex)
            {
                if(FenceHeights[leftIndex] > FenceHeights[rightIndex])
                {
                    return FenceHeights[rightIndex] * 2 > FenceHeights[leftIndex] ? FenceHeights[rightIndex] * 2 : FenceHeights[leftIndex];
                }
                else
                {
                    return FenceHeights[leftIndex] * 2 > FenceHeights[rightIndex] ? FenceHeights[leftIndex] * 2 : FenceHeights[rightIndex];
                }
            }
            else
            {
                maxArea = GetMaxArea(leftIndex, middleIndex) > GetMaxArea(middleIndex + 1, rightIndex) ? GetMaxArea(leftIndex, middleIndex) : GetMaxArea(middleIndex + 1, rightIndex);

                maxArea = GetMaxArea(middleIndex, middleIndex + 1) > maxArea ? GetMaxArea(middleIndex, middleIndex + 1) : maxArea;

                bool isWidth2 = GetMaxArea(middleIndex, middleIndex + 1) > FenceHeights[middleIndex] && GetMaxArea(middleIndex, middleIndex + 1) > FenceHeights[middleIndex + 1];
                int middleHeight = FenceHeights[middleIndex] > FenceHeights[middleIndex + 1] ? FenceHeights[middleIndex + 1] : FenceHeights[middleIndex];

                int currentLeft = middleIndex;
                int currentRight = middleIndex + 1;
                while(isWidth2 && (leftIndex < currentLeft || currentRight < rightIndex))
                {
                    if(currentRight < rightIndex && (currentLeft == leftIndex || FenceHeights[currentLeft - 1] < FenceHeights[currentRight + 1]))
                    {
                        currentRight++;
                        middleHeight = middleHeight < FenceHeights[currentRight] ? middleHeight : FenceHeights[currentRight];
                    }
                    else
                    {
                        currentLeft--;
                        middleHeight = middleHeight < FenceHeights[currentLeft] ? middleHeight : FenceHeights[currentLeft];
                    }

                    maxArea = maxArea > middleHeight * (currentRight - currentLeft + 1) ? maxArea : middleHeight * (currentRight - currentLeft + 1);
                }

                return maxArea;
                            }

        }
    }


}
