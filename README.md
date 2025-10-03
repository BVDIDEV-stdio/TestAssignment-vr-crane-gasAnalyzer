# TestAssignment-vr-crane-gasAnalyzer


**⚠️WARNING⚠️**
- you might need lfs installed

**CRANE CONTROLLER**
In the project you can move crane:
- **Forward:** move the crane girder forward
- **Back:** move the crane girder back
- **Right:** move the hois right
- **Left:** move the hoist left
- **Up:** lift up the hook
- **Down:** lower the hook
All buttons (*except for the <u>Up button</u>*) functionality is implemented by <ins>**EventButton.cs**</ins>. Up button relies on <ins>**DelayedEventButton.cs : EventButton**</ins>.

Let me elaborate further on *<ins>HOW</ins>* clicking buttons works here, in VR. Well we've got installed ***<ins>Vive Input Utility</ins>*** plugin installed and hence we have to use its API to initialize button clicking, grabbing and all the other kinds of interacting VR world. That means that we'll have to inherit from <ins>VIU interfaces</ins> in our <ins>**EventButton.cs**</ins>: 
'''IColliderEventClickHandler, 
IColliderEventPressEnterHandler, 
IColliderEventPressExitHandler'''
