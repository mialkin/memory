STARTUP_PROJECT := src/Memory

.PHONY: run
run:
	dotnet run --project $(STARTUP_PROJECT)

.PHONY: watch
watch:
	dotnet watch --project $(STARTUP_PROJECT) --no-hot-reload
