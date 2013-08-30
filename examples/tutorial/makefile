TARGET = tutorial

SOURCES = tutorial.cs
CFC_DIR = ..

all: $(TARGET).exe

$(TARGET).exe:$(SOURCES)
  csc /reference:netfscc.dll /out:$@ $(SOURCES) /platform:x86 
  
clean:
  del *.exe