SETUP
To use this unity map, it requires the use of the Fove VR headset. As such their minimum and recommended PC specifications are listed below. The minimum specifications are the bare minimum parts to run the unity project and the fove. The recommended specs were chosen based upon the machines that we built the project on along with the mobile gaming laptops that we were also used to develop the project. 

NOTE: during the development, independent reports were found that suggested that the Nvidia RTX 20 series graphics cards were causing issues with compatibility with the fove. At the time of this writing, Fove has not made a statement on this and thus seems to be isolated cases. However, due to other factors and reports of technical and hardware failure of the RTX lines, it is recommended to get GTX 10 series cards for their wider availability and better technical/driver support.

Minimum
CPU: Intel core i5-4590 or equivalent
GPU: Nvidia GeForce GTX 970 or equivalent
RAM: 8GB
Interface: HDMI 1.4 / USB 3.0 / USB 2.0 x 2
OS: Windows 8.1 64-bit or Windows 10 64-bit

Recommended
CPU: Intel i7-6700K or equivalent
GPU: Nvidia Geforce GTX 1060 6GB or equivalent
RAM: 12GB or more
Interface: HDMI 2.0 / USB 3.0 / USB 2.0 X 2
OS: Windows 10 64-bit

Extra notes 
We have found that it is best to plug the HDMI port into the graphics card over the motherboard. Unity’s FAQ recommends that displays and headsets be plugged into the graphics card for better performance.
The fove tracker script is setup to capture data on every frame call within unity. In most cases, 60FPS will mean 60 lines of data per second. There is no framerate cap programmed in to allow for the recorder to record as fast as the system resources will allow.


DURING TEST
    Before starting the test, Go into the fove debug menu, and calibrate the user, once that is done, start the unity project (note this can be done through the editor or through a final executable). When the scene has been started, press the spacebar to begin the tracking system and the user will be clear to begin. The user will have two controls, left click will indicate a users selection, and right click will allow the user to advance to the next scene. when the user finishes after test 8 has left click, The unity program will automatically exit and stop recording when they advance past 8 tests. All data will be recorded into the “fove_recorded results”.

EXCEL EDITING

- make a copy of your newly created .csv file for backup purposes just in case. 

- Next, open up the .csv file in Microsoft Excel.

- Select the Q column and highlight the whole column.

- Next, go to Data > Filter and click on the filter button

- A small box on cell Q1 will have appeared, click on it to show the drop-down menu
Unselect select-all and select only the scene you want or need

- The .csv file will now only show the data by the indicated scene in the filter drop-down

- Next save your file separately through save-as to preserve the individual scenes

- Repeat as necessary until you have the data you wish to use.

    NOTE:
- by using the filter function the unneeded rows are only hidden and all the data is retained in each file. Importing the file into Matlab will only show the unhidden rows, the rest will be ignored.
- by selecting the columns and clicking the filter button will apply a filter to all columns. Use this if you need to visualize a specific situation in the data. For example, Using column R filtered to ‘+’ and column Q filtered to a specific scene will allow you to filter only the data when the user is indicating their answer. Use this to filter as needed and be sure to save each one as needed.


MATLAB IMPORTING
For Matlab importing make a copy of the csv or accel file or files that you wish to visualize and put them in the desktop file directory to make finding the file easier in the Matlab interface. 

Next double click file you wish to import on the left side of the Matlab interface to open the import pop-up.

Matlab should have all the settings required to set up by default. Just in case the settings at the top of the interface should be as follows from left to right:
Select: delimited
Column delimiters: comma
Range: A2:S(bottom row)
Variable Names row: 1
Output type: table

After all, settings are confirmed click the import selection button or the green checkmark to import the table to a Matlab variable

After Matlab has parsed the .csv file return to the main Matlab interface from before, the CSV file will appear in the workspace column on the right side of the interface. Double click this to open the CSV file in Matlab proper.

Now with the data in Matlab, we can pick certain values/columns and plot them visually. Some possible combinations include:
leftGaze origin x, leftGaze origin y, leftGaze origin z - in Scatter3 plot
rightGaze origin x, rightGaze origin y, rightGaze origin z - in Scatter3 plot
leftGaze direction x, leftGaze direction y, leftGaze direction z - in Scatter3 plot
rightGaze direction x, rightGaze direction y, rightGaze direction z - in Scatter3 plot
isLookingAtObject, Objectidentification, objectLocation - in Pie Chart, or histogram

After you make a selection, click plots at the top left of the interface and click the appropriate plot you wish to use. We would recommend the following plots in general (spelling matches Matlab's interface):
    Scatter3 plot
    Pie
bar 
Histogram
    
    NOTE:
 to select multiple columns in Matlab use CTRL + right mouse click, the most that Matlab can handle is 3 values.
Matlab also only shows one visualization at a time to prevent the accidental loss of the visualizations save each plot you need or create for backup purposes.





