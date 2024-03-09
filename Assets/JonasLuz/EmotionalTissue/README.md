# Emotional Tissue
Emotional Tissue is a Unity widget to represent a game character's emotional inner state. 

Published as a paper for the SBGames'22, [Emotional Tissue: A Visual Representation of Characters' Emotional States in Games](https://doi.org/10.1109/SBGAMES56371.2022.9961085). Basically, it is a visual shader applied to a cloth circular mesh, that depicts 4, 6 or 8 colors, each semantically representing an emotion; then a specifically designed camera that shows this "emotional tissue" is rendered into a texture that is, then, showed in the scene GUI as a widget.

Please read the LICENSE information before using this software.

## Installing
Emotional Tissue is published as a Unity package and can be used in Unity 2021 or later. One just need to add the package from inside your Unity project.

After importing the content of the package into the Unity project, one will find the path ```JonasLuz/EmotionalTissue``` inside the project's  ```Assets``` folder.

## Using the widget
1. In the ```Prefabs``` subfolder one will find the ```EmotionalTissue_Rig``` prefab. One must drag it to the scene. The widget is composed of cloth 3D mesh to which a shader is applied, a camera which image is rendered in a special texture, and a canvas UI where the texture is rendered.
1. Normally, one will keep the Emotional Tissue rig outside of the main camera view. One can simply put it behind the camera of out of its frustrum, or you can keep the rig into a layer that the main camera won't render.
1. Then, one will probably want to adjust the widget position in the rig canvas, so it will appear as desired in your scene interface.
1. Finally, once the widget is completly set up in the scene, one is now ready to program its behaviour. For it, one will use the API available in the ```EmotionalTissueControl``` component attached to the ```EmotionalTissue``` node inside the rig. The API offers the following methods:

    * ```void InitColors(NumberOfColors noc)``` - Initialize the widget with the selected number of colours: 4, 6 or 8. 
    * ```void Add(string emotion, Color color)``` - Sets an emotion and its colour. Used to setup Emotional Tissue.
    * ```Color GetColor(int index)``` - Retrieves the colour of the shader parameter of the given index.
    * ```Color GetColor(string emotion)``` - Retrieves the colour assigned to the target emotion.
    * ```void SetColor(int index, Color color)``` - Assigns the indicated colour to the colour parameter with the given index.
    * ```void SetColor(string emotion, Color color)``` - Assigns the specified colour to an emotion.
    * ```float GetValue(int index)``` - Retrieves the intensity value, normalized between 0 and 1, of the colour with the given index parameter.
    * ```float GetValue(string emotion)``` - Retrieves the intensity value, normalized between 0 and 1, of a given emotion.
    * ```void SetValue(int index, float value)``` - Assigns the intensity value, normalized between 0 and 1, of the colour parameter with the given index.
    * ```void SetValue(string emotion, float value)``` - Sets the intensity value, normalized between 0 and 1, of the given emotion.
    * ```void ResetValue(int index)``` - Resets the colour intensity value with parameter with the given index.
    * ```ResetValue(string emotion)``` - Resets the intensity value of a given emotion.

The logic of using Emotional Tissue is entirely up to the game designer and depends on the role emotions play in gameplay. Although there are no impediments to using EmotionalShader directly, the prefab offers an API that allows changing the emotions’ colours and their corresponding intensities.

Finally, the package contains a demo scene, in the ```Demo/Scenes``` subfolder, called ```BasicUse```. It uses an Monobehaviour based script that serves as an example of programming of the widget through the given API. The script is available in the ```Demo/Scripts/BasicUse.cs``` file.