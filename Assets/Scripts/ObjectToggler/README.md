# Object Toggler

## About
In any projects one of the most important parts is their optimization for devices.

I created ObjectToggler to simplify working with objects in the UI, but no one forbids you to use this tool for other switching objects.

This project is an example of switching pages and popups.

## Warning
To use this tool, you need to import DoTween into your project, since it is what plays the animation.  

Only one object can be active at a time from "Case" list.

## Main Information

Main class is ObjectToggler. 

All the logic of switching objects inside it.

It contains next fields: 
  - Object Toggler Control (It help to call methods for toggling objects)
  - Enable On Init (It help to make visible initial Page or Popup)
  - Cases (In this list you add all the cases for interaction)
    - Case Name (It contains name for Case)
    - Case Object (It contains reference on Page or Popup transform)
    - Transition (It help animate switching object by opening) - Will appear when you fill "Enable On Init" field
    - Back Transition (It help animate switching object by closing) - Will appear when you fill "Enable On Init" field

ObjectTogglerControl has next methods for manage objects visibility:
   - Toggle (Can switch object with "Transition" animation)
   - ToggleBackward (Can switch object with "Back Transition" animation)
   - DisableAll (Can close object, use for switching object without transition animation)

## How use

* First step:
    - Add ObjectToggler component on Canvas/Canvases.

* Second step:
    - Create ObjectTogglerControl from "Create/ObjectTogglerMenu/ObjectTogglerControl" by right clicking or from the "Assets" menu

    - Add a reference to this configuration in the ObjectToggler field for it

* Third step:
    - Create Transitions what you need from "Create/ObjectTogglerMenu/Transitions" by right clicking or from the "Assets" menu

    - Add references in the appropriate fields in ObjectToggler 

* Fourth step:
    - Add on Button or Toggle in click event one of yours created ObjectTogglerControl 
    - Chose one of methods from them (Toggle or ToggleBackward)
    - Enter "CaseName" which you want to switch

## Helpful Notes

If you enter an incorrect "CaseName" and try to call the switch methods, you will see an error in the console.
```
This object doesn't exist. Check that the Name ({caseName}) field is correct
```