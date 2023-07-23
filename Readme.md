# THE SOURCE CODE was intented to be PRIVATE     
-only process recorded-    
***
-2023/7/18-     
Tasks: Initialize Project Settings   
Unity Version-2020.3.20f1c1 (with 3 Plug-ins：OpenXR Plugin，XR Interaction Tookit and XR Plugin Management)   
Oculus Quest2(Android Platform)      
Problem: Cannot link Quest2 to PC (Running Unity platform)    
***
-2023/7/19-    
Tasks done:    
· Problem Solved: Unauthorization problem, reset VR hardware device, and solve.   
https://github.com/0FFMIND/SummerController/blob/main/7_20_UnityCube2VR.jpg      
· ARM model source link: https://github.com/cambel/ur3/tree/noetic-devel/ur3_description   
Unity Package Added: URDF package (https://github.com/Unity-Technologies/URDF-Importer) Then we could import Robot model from URDF   
· Create new folder called URDF to import ARM model into Unity   
Problem: ARM file is .xacro, and needs to be converted into .urdf form  
Solved: Run ROS command to convert Xacro to URDF,   
Use VMware workstation to create new ubuntu virtual machine,    
username: offmind password: 0*****, with c++ added.(disposal)   
***
-2023/7/20-      
Tasks done:   
· New Solution: Add Chocolately and install ROS noetic to Win10, create ROS.exe to run ROS command line in windows :   
rosrun xacro xacro --inorder -o C:\opt\ros\noetic\x64\share\ur3-noetic-devel\ur3_description\urdf\ur3.urdf C:\opt\ros\noetic\x64\share\ur3-noetic-devel\ur3_description\urdf\ur3.urdf.xacro    
For all urdf.xacro files   
Meet new problem: Some urdf.xacro files cannot transform into .xacro for error parameter   
Solved: Source files from github use new one:      https://github.com/nLinkAS/fmauch_universal_robot/tree/calibration_devel   
· Run ROS command line again:    
rosrun xacro xacro --inorder -o C:\opt\ros\noetic\x64\share\fmauch_universal_robot-calibration_devel\ur_description\urdf\ur3e.urdf C:\opt\ros\noetic\x64\share\fmauch_universal_robot-calibration_devel\ur_description\urdf\ur3e.xacro    
· Put model ur3e.urdf file into Unity (successfully!)    
***
-2023/7/21-     
Demo videos:    
https://github.com/0FFMIND/SummerController/blob/main/7_21_UnitySimuRobot.mp4
https://github.com/0FFMIND/SummerController/blob/main/7_21_VRHandControlRbt.mp4
***
-2023/7/22-   
With oral introduction:   
https://github.com/0FFMIND/SummerController/blob/main/7_22_FirstWeekDemo.mp4   
***
-2023/7/24-      
· Next: Inverse Kinematics should be added to robotic ARM (IK).    
· Running a Linux image in Windows and having a ROS connection with Unity, Windows Subsystem for Linux (WSL) is chosen.   https://github.com/0FFMIND/SummerController/blob/main/Images/WSL2_Function.png     
· PC needs to install Windows Insider Preview Builds（Successfully）. For using Linux subsystem in win10, we need to open PowerShell with administration, and type wsl.exe --> then username: offmind login with password 0*****      
· Linux command: sudo vim /etc/sudoers --> Shift + I (Edit) --> Esc --> :wq! (save and exit), add lines:      
%sudo ALL=(ALL) NOPASSWD: /usr/sbin/service docker *      
%sudo ALL=(ALL) NOPASSWD: /usr/sbin/service cron *       
Then create wslservices.bat in win+R and type shell:startup that can have docker start and cron start     