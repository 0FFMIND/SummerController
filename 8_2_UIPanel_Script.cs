using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.Robotics.ROSTCPConnector;

public class LeftRightButton : MonoBehaviour
{
    [Header("Joint Settings")]
    [SerializeField] private string[] controlJoint = { "shoulder_link", "upper_arm_link", "forearm_link", "wrist_1_link", "wrist_2_link", "wrist_3_link" };
    [SerializeField] private ArticulationBody[] articulationBodies;
    [SerializeField] private int linkNum = 6;
    [SerializeField] private int defaultNum = 0;
    [SerializeField] private ArticulationBody nowJoint = null;
    private ArticulationDrive artDrive;

    [Header("UI Elements")]
    [SerializeField] private GameObject textPro;
    [SerializeField] private Slider slider;
    [SerializeField] private float changeValue = 0f;
    [SerializeField] private TMP_InputField rosIP;
    [SerializeField] private TMP_InputField ipPort;
    [SerializeField] private TMP_Text connectInfo;

    private void OnEnable()
    {
        InitializeArticulationBodies();
    }

    private void InitializeArticulationBodies()
    {
        articulationBodies = new ArticulationBody[linkNum];
        for (int i = 0; i < linkNum; i++)
        {
            articulationBodies[i] = GameObject.Find(controlJoint[i]).GetComponent<ArticulationBody>();
        }
    }

    private void UpdateJointDrive()
    {
        if (nowJoint != null)
        {
            artDrive = nowJoint.xDrive;
            artDrive.target = changeValue;
            nowJoint.xDrive = artDrive;
        }
    }

    public void DefaultClicked()
    {
        for (int i = 0; i < linkNum; i++)
        {
            RestoreDefaultJointState(articulationBodies[i]);
        }
    }

    private void RestoreDefaultJointState(ArticulationBody joint)
    {
        GameObject controlJointObject = GameObject.Find(joint.name);
        ArticulationDrive drive = joint.xDrive;
        drive.target = 0f;
        controlJointObject.GetComponent<ArticulationBody>().xDrive = drive;
        controlJointObject.transform.position = joint.transform.position;
    }

    public void GetValue()
    {
        changeValue = slider.value;
        UpdateJointDrive();
    }

    public void RightClicked()
    {
        defaultNum = (defaultNum + 1) % linkNum;
        UpdateJointUI();
    }

    public void LeftClicked()
    {
        defaultNum = (defaultNum - 1 + linkNum) % linkNum;
        UpdateJointUI();
    }

    private void UpdateJointUI()
    {
        textPro.GetComponent<TextMeshProUGUI>().text = controlJoint[defaultNum];
        nowJoint = GameObject.Find(textPro.GetComponent<TextMeshProUGUI>().text).GetComponent<ArticulationBody>();
        slider.value = GameObject.Find(controlJoint[defaultNum]).GetComponent<ArticulationBody>().xDrive.target;
    }
    public void RosConnect()
    {
        string rosip = rosIP.text.ToString();
        string port = ipPort.text.ToString();
        int pt = int.Parse(port);
        ROSConnection.GetOrCreateInstance().Connect(rosip,pt);
        if (GameObject.Find("ROSConnectionPrefab(Clone)").GetComponent<ROSConnection>().HasConnectionThread)
        {
            connectInfo.text = "succssfully!";
            connectInfo.color = Color.green;
        }
    }
    private void OnFailedToConnect()
    {
        connectInfo.text = "no connection";
        connectInfo.color = Color.red;
    }
}
