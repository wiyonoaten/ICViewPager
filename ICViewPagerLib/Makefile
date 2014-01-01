XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=.
PROJECT=$(PROJECT_ROOT)/ICViewPagerLib.xcodeproj
TARGET=ICViewPagerLib

all: libICViewPagerLib.a

libICViewPagerLib-i386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libICViewPagerLib-armv7.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libICViewPagerLib.a: libICViewPagerLib-i386.a libICViewPagerLib-armv7.a
	lipo -create -output $@ $^
	rm $^

clean:
	-rm -f *.a
