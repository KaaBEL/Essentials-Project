//using UnityEditor;
//using UnityEngine;

//public class MenuTest : MonoBehaviour
//{
//    // Add a menu item named "Do Something" to MyMenu in the menu bar.
//    [MenuItem("Test/Do Something")]
//    static void DoSomething()
//    {
//        Debug.Log("Doing Something...");
//    }

//    // Add a menu item named "Log Selected Transform Name" to MyMenu in the menu bar.
//    // We want this to be validated menu item: an item that is only enabled if specific conditions are met.
//    // To achieve this, we use a second function below to validate the menu item.
//    // so it will only be enabled if we have a transform selected.
//    [MenuItem("Test/Log Selected Transform Name")]
//    static void LogSelectedTransformName()
//    {
//        Debug.Log("Selected Transform is on " + Selection.activeTransform.gameObject.name + ".");
//    }

//    // Validate the menu item defined by the function above.
//    // The "Log Selected Transform Name" menu item is disabled if this function returns false.
//    // We tell the Editor that this is a validation function by decorating it with a MenuItem attribute
//    // and passing true as the second parameter.
//    // This invokes the MenuItem(string itemName, bool isValidateFunction) attribute constructor
//    // resulting in the function being treated as the validator for "Log Selected Transform Name" menu item.
//    [MenuItem("Test/Log Selected Transform Name", true)]
//    static bool ValidateLogSelectedTransformName()
//    {
//        // Return false if no transform is selected.
//        return Selection.activeTransform != null;
//    }

//    // Add a menu item named "Do Something with a Shortcut Key" to MyMenu in the menu bar
//    // and give it a shortcut (ctrl-g on Windows, cmd-g on macOS).
//    [MenuItem("Test/Do Something with a Shortcut Key %g")]
//    static void DoSomethingWithAShortcutKey()
//    {
//        Debug.Log("Doing something with a Shortcut Key...");
//    }

//    // Add a menu item called "Double Mass" to a Rigidbody's context menu.
//    [MenuItem("CONTEXT/Rigidbody/Double Mass")]
//    static void DoubleMass(MenuCommand command)
//    {
//        Rigidbody body = (Rigidbody)command.context;
//        body.mass = body.mass * 2;
//        Debug.Log("Doubled Rigidbody's Mass to " + body.mass + " from Context Menu.");
//    }

//    // Add a menu item to create custom GameObjects.
//    // Priority 10 ensures it is grouped with the other menu items of the same kind
//    // and propagated to the hierarchy dropdown and hierarchy context menus.
//    [MenuItem("GameObject/MyCategory/Custom Game Object", false, 10)]
//    static void CreateCustomGameObject(MenuCommand menuCommand)
//    {
//        // Create a custom game object
//        GameObject go = new GameObject("Custom Game Object");
//        // Ensure it gets reparented if this was a context click (otherwise does nothing)
//        GameObjectUtility.SetParentAndAlign(go, menuCommand.context as GameObject);
//        // Register the creation in the undo system
//        Undo.RegisterCreatedObjectUndo(go, "Create " + go.name);
//        Selection.activeObject = go;
//    }

//    // Add a menu item called "Test" to the Scene view context menu when the
//    // EditorToolContext "TestToolContext" is engaged.
//    [MenuItem("CONTEXT/TestToolContext/Test")]
//    static void TestToolContextItem()
//    {
//        Debug.Log("Testing Test Tool Context Menu Item");
//    }

//    // Add a menu item called "Test" to the Scene view context menu when the
//    // EditorTool "TestTool" is engaged.
//    [MenuItem("CONTEXT/TestTool/Test")]
//    static void TestToolItem()
//    {
//        Debug.Log("Testing Test Tool Menu Item");
//    }
//}
