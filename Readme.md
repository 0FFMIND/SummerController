-2023/7/18-
Tasks: Initialize Project Settings
Unity Version-2020.3.20f1c1(with 3 Plug-ins
OpenXR Plugin
XR Interaction Tookit
XR Plugin Management
)
Oculus Quest2(Android Platform)
Problem: Cannot link Quest2 to PC(Running Unity platform)
-2023/7/19-
Tasks done: 
1. Problem Solved: Unauthorization problem, reset VR hardware device, and solve.
2. ARM model source link: https://github.com/cambel/ur3/tree/noetic-devel/ur3_description
Unity Package Added: URDF package (https://github.com/Unity-Technologies/URDF-Importer) Then we could import Robot model from URDF
3. Create new folder called URDF to import ARM model into Unity
Problem: ARM file is .xacro, and needs to be converted into .urdf form
Solved: Run ROS command to convert Xacro to URDF, 
Use VMware workstation to create new ubuntu virtual machine,
username: offmind password: 020509, with c++ added.(disposal)
-2023/7/20-
Tasks done:
1. New Solution: Add Chocolately and install ROS noetic to Win10, create ROS.exe to run ROS command line in windows :
rosrun xacro xacro --inorder -o C:\opt\ros\noetic\x64\share\ur3-noetic-devel\ur3_description\urdf\ur3.urdf C:\opt\ros\noetic\x64\share\ur3-noetic-devel\ur3_description\urdf\ur3.urdf.xacro
For all urdf.xacro files
Meet new problem: Some urdf.xacro files cannot transform into .xacro for error parameter
Solved: Source files from github use new one:https://github.com/nLinkAS/fmauch_universal_robot/tree/calibration_devel
2. run ROS command line again:
rosrun xacro xacro --inorder -o C:\opt\ros\noetic\x64\share\fmauch_universal_robot-calibration_devel\ur_description\urdf\ur3e.urdf C:\opt\ros\noetic\x64\share\fmauch_universal_robot-calibration_devel\ur_description\urdf\ur3e.xacro
2. Put model ur3e.urdf file into Unity (successfully!)
-2023/7/21-
Demo videos:


