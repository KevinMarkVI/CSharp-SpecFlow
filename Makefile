all: clean build test

clean:
	msbuild /t:clean /p:Configuration=Release


build:
	msbuild /t:build /p:Configuration=Release

test:
	nunit3-console UnitTestProject1.sln /config:Release --workers=9