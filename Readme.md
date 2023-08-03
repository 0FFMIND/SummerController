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
username: offmind password: 0*****, with c++ added. 
***
-2023/7/20-      
Tasks done:   
· New Solution(in Windows, more convenience): Add Chocolately and install ROS noetic to Win10, create ROS.exe to run ROS command line in windows :   
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
· Running a Linux image in Windows and having a ROS connection with Unity    
~~· Windows Subsystem for Linux (WSL) is chosen.   https://github.com/0FFMIND/SummerController/blob/main/Images/WSL2_Function.png     
PC needs to install Windows Insider Preview Builds（Successfully）. For using Linux subsystem in win10, we need to open PowerShell with administration, and type wsl.exe~~（Discarded）     
***
-2023/7/25-      
· Unity Side: Add new package https://github.com/Unity-Technologies/ROS-TCP-Connector.git?path=/com.unity.robotics.ros-tcp-connector for communication with ROS    
· For ROS Image, this project use VMstation Ubuntu ROS-noetic image(In 2023/7/19, new Virtual machine is created with ubuntu 20.04LTS).    
· Add ROS-noetic to offmind machine, solution link for unexpected errors:    
· For ROS-noetic, use Ubuntu.iso 20.04 LTS, and add python3-rosdep2 to Virtual machine.      
https://blog.csdn.net/qq_44339029/article/details/120579608)    
· Successfully: https://github.com/0FFMIND/SummerController/blob/main/7_25_VM_ROSterminal.png
***
-2023/7/26-      
· Virtual Machine Side: Create catkin packages (build a catkin workspace http://wiki.ros.org/catkin/Tutorials/create_a_workspace)      
· cd ~/catkin_ws --> catkin_make (Compiling the workspace) --> source devel/setup.bash (Setting environment variables) -->  roslaunch ros_tcp_endpoint endpoint.launch      
· Successfully: https://github.com/0FFMIND/SummerController/blob/main/7_26_ROS_endpoint.png     
***
-2023/7/27-    
· Unity in Windows cannot have TCP connection to ROS in Virtual Machine     
Error picture:     
https://github.com/0FFMIND/SummerController/blob/main/7_27_TCP_Error.png
https://github.com/0FFMIND/SummerController/blob/main/7_27_TCP_ErrorDifferentIp.png
· Solved: PC and Virtual machine have different ip, and cannot use 127.0.0.1 this simple callback address to send and receive message. The ROS address in PC should be set to 192.168.163.132 (forced). For ROS terminal, it opens endpoint at ip address 0.0.0.0 to receive all package sent to this ROS system, the open port we choose to be 10000.
· Command lines in Linux added: sudo -i --> rootuser --> echo "xxx" 
’>‘> /home/offmind/catkin_ ws/src/CMakeLists.txt        
run publisher.py in Linux, and subscriber in Unity.(Succssfully!)
· Windows Video:https://github.com/0FFMIND/SummerController/blob/main/7_27_Unity_SimuCube.mp4    
***    
-2023/7/28-    
· VR Demo video:https://github.com/0FFMIND/SummerController/blob/main/7_28_SecondWeek_VRconnection.mp4    
· With oral introduction:https://github.com/0FFMIND/SummerController/blob/main/7_28_SecondWeek_Demo.mp4    
***
-2023/7/31-    
· Setting up the robot in Unity: Change the solver type to 'Tmeporal and Gauss seidel' (Prevent erratic behavior in the joints)    
· Change The default joint settings in https://github.com/Unity-Technologies/Unity-Robotics-Hub/blob/main/tutorials/pick_and_place/1_urdf.md      
· Stiffness -> 10000, Damping -> 100, Force Limit -> 1000, Speed -> 30, Torque --> 100, Acceleration -> 10.     
· Add Moveit message package to Unity Side: https://github.com/ros-planning/moveit_msgs    
***
-2023/8/1-   
· Add all joint in ur3e （Unity）to Moveit config: public static readonly string[] LinkNames =
        {"base_link/base_link_inertia/shoulder_link", "/upper_arm_link", "/forearm_link", 
        "/wrist_1_link", "/wrist_2_link", "/wrist_3_link"};      
Add moveit to ROS (in Virtual Machine) command : sudo apt-get update && sudo apt-get upgrade -> sudo apt-get install python3-pip ros-noetic-robot-state-publisher ros-noetic-moveit ros-noetic-rosbridge-suite ros-noetic-joy ros-noetic-ros-control ros-noetic-ros-controllers -> sudo -H pip3 install rospkg jsonpickle (Successfully
！)      
· Make connection to Unity moveit and ROS moveit(with TCP connection), and successfully, with Unity machine to be publisher and publish basic info to ROS subsriber, and new UI :https://github.com/0FFMIND/SummerController/blob/main/8_1_MoveitTCP_Connection.png           
***
-2023/8/2-     
· Update new UI panel and update the UI panel control for Unity ur3e model, and the updated script runs succussfully:       
https://github.com/0FFMIND/SummerController/blob/main/8_2_UIPanel_Script.cs     
https://github.com/0FFMIND/SummerController/blob/main/8_2_NewUI_panel.png     
· Continue update UI panel and for ROS moveit, errors need to be fixed.    
https://github.com/0FFMIND/SummerController/blob/main/8_2_Updated_UIpanel.png
https://github.com/0FFMIND/SummerController/blob/main/8_2_ROS_errormsg.png   
***
-2023/8/3-    

***