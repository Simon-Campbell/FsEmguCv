// After setting up dependencies this script can be executed in
// F# Interactive (ALT+ENTER) in Visual Studio. It's a very basic
// script and is a port of the following C# script:
//  http://www.emgu.com/wiki/index.php/Hello_World_in_CSharp
// - Check out Scripts/load-references.fsx for the directory a build
//      of Emgu CV is expected in.
// - See README.md for a few notes on how to generate the binaries
// - Do not expect this to work without setting up the dependencies
// we don't care about the result so we'll pipe the output
// into ignore (this is a blocking call)
// make use of the function declared above and
// create a window with "Hello, World"
module Script

#load "Scripts/load-project.fsx"

open Emgu.CV
open Emgu.CV.Structure
open Emgu.CV.CvEnum

let putText = CvInvoke.PutText
let createNamedWindow = CvInvoke.NamedWindow
let showImage = CvInvoke.Imshow
let waitKey x = CvInvoke.WaitKey x
let destroyWindow = CvInvoke.DestroyWindow
let createBgr b g r = Bgr(b, g, r)
let createMat rows cols depthType channels = new Mat(rows, cols, depthType, channels)

let makeWindow windowName = 
    let blue = createBgr 255.0 0.0 0.0
    let green = createBgr 0.0 255.0 0.0
    let point = System.Drawing.Point(10, 80)

    createNamedWindow windowName

    use img = createMat 200 400 DepthType.Cv8U 3
    img.SetTo(blue.MCvScalar)

    putText (img, "Hello, World", point, FontFace.HersheyComplex, 1.0, green.MCvScalar)
    showImage (windowName, img)

    waitKey -1 |> ignore

    destroyWindow windowName

makeWindow "Test Window"
