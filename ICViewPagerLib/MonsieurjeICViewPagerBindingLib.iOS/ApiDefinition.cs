using System;
using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MonsieurjeICViewPagerBindingLib 
{
	// The first step to creating a binding is to add your native library ("libNativeLibrary.a")
	// to the project by right-clicking (or Control-clicking) the folder containing this source
	// file and clicking "Add files..." and then simply select the native library (or libraries)
	// that you want to bind.
	//
	// When you do that, you'll notice that MonoDevelop generates a code-behind file for each
	// native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
	// architectures that the native library supports and fills in that information for you,
	// however, it cannot auto-detect any Frameworks or other system libraries that the
	// native library may depend on, so you'll need to fill in that information yourself.
	//
	// Once you've done that, you're ready to move on to binding the API...
	//
	//
	// Here is where you'd define your API definition for the native Objective-C library.
	//
	// For example, to bind the following Objective-C class:
	//
	//     @interface Widget : NSObject {
	//     }
	//
	// The C# binding would look like this:
	//
	//     [BaseType (typeof (NSObject))]
	//     interface Widget {
	//     }
	//
	// To bind Objective-C properties, such as:
	//
	//     @property (nonatomic, readwrite, assign) CGPoint center;
	//
	// You would add a property definition in the C# interface like so:
	//
	//     [Export ("center")]
	//     PointF Center { get; set; }
	//
	// To bind an Objective-C method, such as:
	//
	//     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
	//
	// You would add a method definition to the C# interface like so:
	//
	//     [Export ("doSomething:atIndex:")]
	//     void DoSomething (NSObject object, int index);
	//
	// Objective-C "constructors" such as:
	//
	//     -(id)initWithElmo:(ElmoMuppet *)elmo;
	//
	// Can be bound as:
	//
	//     [Export ("initWithElmo:")]
	//     IntPtr Constructor (ElmoMuppet elmo);
	//
	// For more information, see http://docs.xamarin.com/ios/advanced_topics/binding_objective-c_libraries
	//

	[BaseType (typeof (UIViewController))]
	public partial interface ViewPagerController 
	{
		[Export ("initWithNibName:bundle:")]
		IntPtr Constructor([NullAllowed] string nibName, [NullAllowed] NSBundle bundle);

		[Export ("dataSource", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDataSource { get; set; }
		[Wrap ("WeakDataSource")]
		ViewPagerDataSource DataSource { get; set; }

		[Export ("delegate", ArgumentSemantic.Assign), NullAllowed]
		NSObject WeakDelegate { get; set; }
		[Wrap ("WeakDelegate")]
		ViewPagerDelegate Delegate { get; set; }

		[Export ("reloadData")]
		void ReloadData ();

		[Export ("selectTabAtIndex:")]
		void SelectTabAtIndex (uint index);

		[Export ("setNeedsReloadOptions")]
		void SetNeedsReloadOptions ();

		[Export ("setNeedsReloadColors")]
		void SetNeedsReloadColors ();

		[Export ("valueForOption:")]
		float ValueForOption (ViewPagerOption option);

		[Export ("colorForComponent:")]
		UIColor ColorForComponent (ViewPagerComponent component);
	}

	[Model, Protocol, BaseType (typeof (NSObject))]
	public partial interface ViewPagerDataSource
	{
		[Abstract, Export ("numberOfTabsForViewPager:")]
		uint NumberOfTabsForViewPager (ViewPagerController viewPager);

		[Abstract, Export ("viewPager:viewForTabAtIndex:")]
		UIView ViewForTabAtIndex (ViewPagerController viewPager, uint index);

		[Export ("viewPager:contentViewControllerForTabAtIndex:")]
		UIViewController ContentViewControllerForTabAtIndex (ViewPagerController viewPager, uint index);

		[Export ("viewPager:contentViewForTabAtIndex:")]
		UIView ContentViewForTabAtIndex (ViewPagerController viewPager, uint index);
	}

	public interface IViewPagerDataSource {}

	[Model, Protocol, BaseType (typeof (NSObject))]
	public partial interface ViewPagerDelegate 
	{
		[Export ("viewPager:didChangeTabToIndex:")]
		void DidChangeTabToIndex (ViewPagerController viewPager, uint index);

		[Export ("viewPager:valueForOption:withDefault:")]
		float ValueForOption (ViewPagerController viewPager, ViewPagerOption option, float defaultValue);

		[Export ("viewPager:colorForComponent:withDefault:")]
		UIColor ColorForComponent (ViewPagerController viewPager, ViewPagerComponent component, UIColor defaultColor);
	}

	public interface IViewPagerDelegate {}
}
