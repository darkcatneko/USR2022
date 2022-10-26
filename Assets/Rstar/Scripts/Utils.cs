using UnityEngine;

public class Utils : MonoBehaviour
{

    public static Vector3 ScreenToWorld(Camera camera, Vector3 position)
    {
        position.z = 10;
        return camera.ScreenToWorldPoint(position);
    }


    //2D
    public static Vector3 GetMouseWorldPosition()//camera's projection need to set to Orthographic
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }

    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)//camera's projection need to set to Orthographic
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }


    public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 position = default(Vector3), int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.UpperLeft, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = 5000)
    {
        if (color == null) color = Color.white;
        return CreateWorldText(parent, text, position, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
    }

    public static TextMesh CreateWorldText(Transform parent, string text, Vector3 position, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
    {
        GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
        Transform transform = gameObject.transform;
        transform.SetParent(parent, false);
        transform.position = position;
        if (parent != null)
            transform.localScale = new Vector3(1 / parent.localScale.x, 1 / parent.localScale.y, 1 / parent.localScale.z);
        TextMesh textMesh = gameObject.GetComponent<TextMesh>();
        textMesh.anchor = textAnchor;
        textMesh.alignment = textAlignment;
        textMesh.text = text;
        textMesh.fontSize = fontSize;
        textMesh.color = color;
        textMesh.characterSize = .1f;
        textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
        return textMesh;
    }

    public static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        Vector3 dir = point - pivot; // get point direction relative to pivot
        dir = Quaternion.Euler(angles) * dir; // rotate it
        point = dir + pivot; // calculate rotated point
        return point; // return it
    }

    //Matrix WorldToLocalMatrix
    public static float ConvertDegToRad(float degrees)
    {
        return ((float)Mathf.PI / (float)180) * degrees;
    }

    public static Matrix4x4 GetTranslationMatrix(Vector3 position)
    {
        return new Matrix4x4(new Vector4(1, 0, 0, 0),
                             new Vector4(0, 1, 0, 0),
                             new Vector4(0, 0, 1, 0),
                             new Vector4(position.x, position.y, position.z, 1));
    }

    public static Matrix4x4 GetRotationMatrix(Vector3 anglesDeg)
    {
        anglesDeg = new Vector3(ConvertDegToRad(anglesDeg[0]), ConvertDegToRad(anglesDeg[1]), ConvertDegToRad(anglesDeg[2]));

        Matrix4x4 rotationX = new Matrix4x4(new Vector4(1, 0, 0, 0),
                                            new Vector4(0, Mathf.Cos(anglesDeg[0]), Mathf.Sin(anglesDeg[0]), 0),
                                            new Vector4(0, -Mathf.Sin(anglesDeg[0]), Mathf.Cos(anglesDeg[0]), 0),
                                            new Vector4(0, 0, 0, 1));

        Matrix4x4 rotationY = new Matrix4x4(new Vector4(Mathf.Cos(anglesDeg[1]), 0, -Mathf.Sin(anglesDeg[1]), 0),
                                            new Vector4(0, 1, 0, 0),
                                            new Vector4(Mathf.Sin(anglesDeg[1]), 0, Mathf.Cos(anglesDeg[1]), 0),
                                            new Vector4(0, 0, 0, 1));

        Matrix4x4 rotationZ = new Matrix4x4(new Vector4(Mathf.Cos(anglesDeg[2]), Mathf.Sin(anglesDeg[2]), 0, 0),
                                            new Vector4(-Mathf.Sin(anglesDeg[2]), Mathf.Cos(anglesDeg[2]), 0, 0),
                                            new Vector4(0, 0, 1, 0),
                                            new Vector4(0, 0, 0, 1));

        return rotationX * rotationY * rotationZ;
    }

    public static Matrix4x4 GetScaleMatrix(Vector3 scale)
    {
        return new Matrix4x4(new Vector4(scale.x, 0, 0, 0),
                             new Vector4(0, scale.y, 0, 0),
                             new Vector4(0, 0, scale.z, 0),
                             new Vector4(0, 0, 0, 1));
    }

    public static Matrix4x4 Get_TRS_Matrix(Vector3 position, Vector3 rotationAngles, Vector3 scale)
    {
        return GetTranslationMatrix(position) * GetRotationMatrix(rotationAngles) * GetScaleMatrix(scale);
    }
    //MatrixEnd
}
