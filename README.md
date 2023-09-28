# NumberSortAPI

This is a number sorting API that is built on these requirements: 
We need Web API number ordering solution. This solution should have 2 endpoints:

1. We can pass line of numbers from 1 - 10 (few can be skipped) and these numbers should be ordered and saved to file (for ex. result.txt). For ex. we pass 5 2 8 10 1, this file should be saved with following content 1 2 5 8 10

2. We should be able to load content of latest saved file

 

Requirements:

1. .Net Core project

2. Business service(s) with unit tests

3. Sorting algorithm should be written yourself for ex. bubble sort (it would be nice if this algorithm would be able to handle any size of numbers not only 1 to 10, .NET definitions might be the limit here)

4. Put source code in GIT

5. Use best software engineering practices

 

Bonus points:

1. Multiple sorting algorithms are used and time performance is measured between them.


How to run:
1. Clone the project and Run it in Visual Studio. You should be redirected to a swagger homepage.
2. In the swagger home page you should see 3 endpoints: api/NumberSort/sort, api/NumberSort/latest, api/SortingSpeedComparison/benchmark
3. To test api/NumberSort/sort, paste this in the Request body:
   {
  "numbers": [
   10, 7, 3, 5, 2, 1]
   }
4. To test api/NumberSort/latest, just execute it and you will recieve a response.
5. To test api/SortingSpeedComparison/benchmark paste this in the Request body:
    {
  "numbers": [
   10, 7, 3, 5, 2, 1]
   }
