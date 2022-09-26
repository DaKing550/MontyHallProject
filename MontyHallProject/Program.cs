namespace MontyHallProject
{
    class Program
    {
        static void Main(string[] args)
        {

            Random random = new Random();
            int carPicks = 0;
            int goatPicks = 0;
            int nullPicks = 0;
            int baseDoor = 0;
            int moreDoors = 525;
            var doors = new List<bool?>();
            while (doors.Count < moreDoors)
            {
                doors.Add(false);
            }



            //code to adjust by the user not desired at this time
            //Console.WriteLine("How many times would you like to play the monty hall game");
            int desiredNumberOfTries = 20000;    //int.Parse(Console.ReadLine());
            int numberOfResults = 0;

            while (desiredNumberOfTries > numberOfResults)
            {
                int pickedDoor = random.Next(doors.Count);
                var carDoor = random.Next(doors.Count);
                var changeDoor = true;
                doors[carDoor]=true;

                MontyHallRemoval(doors,ref pickedDoor, changeDoor);

                if (doors[pickedDoor] == true)
                {
                    carPicks++;
                }
                if (doors[pickedDoor] == false)
                {
                    goatPicks++;
                }
                if (doors[pickedDoor] == null)
                {
                    nullPicks++;
                }
                numberOfResults++;
                for(int i = 0; i < doors.Count; i++)
                {
                    doors[i] = false;
                }
            }
            Console.WriteLine($"You Won {carPicks}");
            Console.WriteLine($"You Lost {goatPicks}");
            Console.WriteLine($"You got {nullPicks} problems");
            Console.WriteLine($"With {moreDoors} doors");

            Console.ReadLine();

        }

        private static void MontyHallRemoval(List<bool?> doors, ref int pickedDoor, bool changeDoor)
        {
            
            Random random = new Random();
            var falseDoor = random.Next(doors.Count);
            //set to null from list all except 2 options 
            //if pickeddoor == cardoor randomly choose one door to keep
            if (doors[pickedDoor] == true)
            {
                //picked car door
                //now set to null all other values except for one
                while (falseDoor == pickedDoor)
                {
                    falseDoor = random.Next(doors.Count);
                }
                
                for(var i=0; i < doors.Count; i++ )
                {
                    if(i == pickedDoor || i == falseDoor)
                    {
                        continue;
                    }
                    doors[i] = null;
                }
            }
            //if pickeddoor == goat door keep picked and car door
            if (doors[pickedDoor]==false)
            {
                for (var i = 0; i < doors.Count; i++)
                {
                    if (i == pickedDoor || doors[i] == true)
                    {
                        continue;
                    }
                    doors[i] = null;
                }
            }
            //change choice to the other one
            if (changeDoor)
            {
                var changingDoor = doors.FindIndex(0, doors.Count, d=>d.HasValue && d.Value);
                if (changingDoor == pickedDoor)
                {
                    changingDoor = falseDoor;
                }
                pickedDoor = changingDoor;
            }
            //keep choice
        }
    }
}