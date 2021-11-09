# Capstone-project
A crude Neural Network simulator I first wrote in Turbo Pascal in the early 90s.  This project was an Uplift to C# around 2004.  I had just started developing with Windows Forms at the time, so please don't judge the terrible code.  :D

# Purpose
I first attempted to create a neural network simulator when I started collage in 1990.  I wrote it in Turbo Pascal at the time (on a x286!) and it was based on a High School biology level understanding of how neurons interacted.  10 years later, I rewrote it in C#.  I've toyed with additional enhancments to this over the years, but as AI and ML became commonplace, the chance for this to become anything significant faded into the mists.  Still, I am proud of it.

# To run
1. Clone the project to your local.
2. Open the .sln file in Visual Studios.
3. Click Start.
4. Click Load/Save.
5. Click Load file.
6. Select one of the 3 saved networks.  (1 is the crudest, 3 is the most complex.)
7. Click Run/Edit.
8. Play, Pause, adjust the execution speed.

# What you are seeing.
The white dot is the 'body' of the network.  It will search for green dots (food) while blue dots are obstacles that get in it's way.  It will only search for food when its 'energy' gets below 0, i.e. it gets hungry.  It is also very dumb, having only a few dozen neurons.  If you want to see the specific interactions of neurons, pause the simulation and click the step button to see moment by moment changes in the network.



*Note: Currently a bug won't let you load and run a 2nd network after running a first one.  You need to stop running the application and click Start again.
