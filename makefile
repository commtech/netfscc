TARGET = netfscc

SOURCES = src\Fscc.cs
CFC_DIR = libs\cfscc
LIBS = $(CFC_DIR)\cfscc.lib
LIBSD = $(CFC_DIR)\cfsccd.lib

all: $(TARGET).dll
debug: $(TARGET)d.dll

$(TARGET).dll:$(SOURCES) $(LIBS)
  rc $(TARGET).rc
  csc /linkresource:$(CFC_DIR)\cfscc.dll /t:library /out:$@ $(SOURCES) /platform:x86 /win32res:$(TARGET).res

$(TARGET)d.dll:$(SOURCES) $(LIBSD)
  rc /d _DEBUG /fo $(TARGET)d.res $(TARGET).rc
  csc /linkresource:$(CFC_DIR)\cfsccd.dll /t:library /out:$@ $(SOURCES) /platform:x86 /debug /define:DEBUG /win32res:$(TARGET)d.res

$(LIBS):
  pushd $(CFC_DIR) & nmake & popd

$(LIBSD):
  pushd $(CFC_DIR) & nmake DEBUG & popd

clean:
  del *.dll