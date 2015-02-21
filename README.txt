Example of pinch gesture implementation with reactive programming for Unity
===========================================================================

Abstract
--------

This project is an example for pinch gesture implementation with
reactive programming on Unity.

Major files
-----------

Assets/Scripts/Scaling.cs

    Scaling represents scale and center point.

Assets/Scripts/PinchGesture.cs

    Implementation of pinch gesture with reactive programming.

    ScaleEvent and Scaling class represent scale is changed
    by pinch gesture.

Assets/Scripts/MainCamera.cs

    Main camera receives ScaleEvent and update the screen to refrect its scale.

Required environment
--------------------

* Unity 5.0.0f4 Personal

* UniRx ver.4.7 (including in UniRx directory on this project)

* Device with touch screen
    (I checked running this project with Android 4.3, 4.4)

License
-------

This project is licensed under MIT License
    Copyright (c) 2015 Keita Kita

UniRx (https://github.com/neuecc/UniRx) is licensed under MIT License
    Copyright (c) 2014 Yoshifumi Kawai

