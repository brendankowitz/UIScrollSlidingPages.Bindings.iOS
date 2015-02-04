XBUILD=/Applications/Xcode.app/Contents/Developer/usr/bin/xcodebuild
PROJECT_ROOT=.
PROJECT=$(PROJECT_ROOT)/UIScrollSlidingPagesBindings.xcodeproj
TARGET=UIScrollSlidingPagesBindings

all: libUIScrollSlidingPagesBindingsSDK.a

libUIScrollSlidingPagesBindings-i386.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphonesimulator -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphonesimulator/lib$(TARGET).a $@

libUIScrollSlidingPagesBindings-armv7.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libUIScrollSlidingPagesBindings-armv7s.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch armv7s -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libUIScrollSlidingPagesBindings-arm64.a:
	$(XBUILD) -project $(PROJECT) -target $(TARGET) -sdk iphoneos -arch arm64 -configuration Release clean build
	-mv $(PROJECT_ROOT)/build/Release-iphoneos/lib$(TARGET).a $@

libUIScrollSlidingPagesBindingsSDK.a: libUIScrollSlidingPagesBindings-i386.a libUIScrollSlidingPagesBindings-armv7.a libUIScrollSlidingPagesBindings-armv7s.a libUIScrollSlidingPagesBindings-arm64.a
	lipo -create -output $@ $^


clean:
	-rm -f *.a *.dll