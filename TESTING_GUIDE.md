# Android KeyboardBehavior Testing Guide

This guide explains how to test the Android KeyboardBehavior detach issue fix to ensure proper event handler cleanup during page navigation.

## The Fix Summary

The fix addresses three critical issues:
1. **Incorrect detachment target**: Event handlers were attached to parent layout but detached from wrong object
2. **ObjectDisposedException crashes**: Layout disposal before detachment causing crashes
3. **Memory leaks**: Event handlers accumulating on singleton pages

## Testing Strategy

### Prerequisites
- Run the sample app on Android device/emulator
- Enable debug output to monitor lifecycle events
- Use Visual Studio debugger or Android Studio to monitor for exceptions

### Test Scenarios

#### 1. Basic Functionality Test
**Objective**: Verify KeyboardBehavior still works correctly
**Steps**:
1. Launch the sample app
2. Press various keys on the main page
3. Verify key events are captured and displayed

**Expected Result**: Key events should be captured and displayed normally

#### 2. Transient Page Navigation Test
**Objective**: Test event handler cleanup on pages that create new instances
**Steps**:
1. Navigate to "Test Navigation Scenarios"
2. Click "Navigate to Transient Page"
3. Press some keys and verify events are captured
4. Navigate back to Navigation Test page
5. Repeat steps 2-4 multiple times (5-10 times)
6. Monitor debug output for disposal messages

**Expected Result**: 
- No ObjectDisposedException crashes
- Each transient page instance should properly clean up
- Debug output should show "OnDisappearing" calls for each instance

#### 3. Singleton Page Navigation Test
**Objective**: Test event handler cleanup on pages that reuse instances
**Steps**:
1. From Navigation Test page, click "Navigate to Singleton Page"
2. Press some keys and verify events are captured
3. Navigate back to Navigation Test page
4. Navigate to Singleton Page again
5. Press keys - events should still work
6. Repeat steps 3-5 multiple times (5-10 times)

**Expected Result**:
- Visit count should increment showing same instance is reused
- Key events should work consistently across all visits
- No duplicate event handlers (events shouldn't multiply)

#### 4. Memory Leak Prevention Test
**Objective**: Verify no event handler accumulation
**Steps**:
1. Navigate between different pages 10-20 times
2. On singleton page, press a key and count events generated
3. Navigate away and back to singleton page
4. Press the same key again and verify event count

**Expected Result**: 
- Should generate same number of events each time (typically 2: KeyDown + KeyUp)
- Events should not multiply indicating proper cleanup

#### 5. Rapid Navigation Test
**Objective**: Test robustness under stress
**Steps**:
1. Rapidly navigate between pages multiple times
2. Navigate away from pages before they fully load
3. Use hardware back button during navigation

**Expected Result**: 
- No crashes or exceptions
- Graceful handling of rapid navigation
- Proper cleanup even with interrupted navigation

## What to Monitor

### Debug Output
Watch for these debug messages:
```
[TransientTestPage] OnDisappearing called
[SingletonTestPage] OnAppearing called
[SingletonTestPage] OnDisappearing called
```

### Exception Monitoring
Watch for these potential issues (should NOT occur):
- `ObjectDisposedException` when detaching handlers
- `NullReferenceException` during cleanup
- Multiple event handlers firing for single key press

### Memory Monitoring
Use Android Studio Profiler or Visual Studio Diagnostics to monitor:
- Memory usage should be stable during navigation
- No increasing memory usage with repeated navigation
- Garbage collection should clean up transient pages

## Automated Testing Considerations

For automated testing, you could:
1. Create unit tests that mock the Android.Views.View lifecycle
2. Add instrumentation tests that programmatically navigate between pages
3. Use memory profilers to verify no leaks in CI/CD pipeline

## Reproducing Original Issues

To verify the fix works, you can temporarily revert the changes and observe:

### Original Issue 1 (Wrong Detachment Target)
```csharp
// Revert to this to see the issue:
protected override void OnDetachedFrom(VisualElement bindable, Android.Views.View platformView)
{
    platformView.KeyPress -= OnKeyPress; // Wrong object!
    base.OnDetachedFrom(bindable, platformView);
}
```
**Expected Behavior**: Events continue firing after navigation (memory leak)

### Original Issue 2 (ObjectDisposedException)
Remove the try-catch block to see crashes when layouts are disposed before detachment.

### Original Issue 3 (Memory Leaks)
Without proper cleanup, singleton pages would accumulate multiple event handlers, causing multiple events for single key presses.

## Verification Checklist

- [ ] Basic key events work on all pages
- [ ] No crashes during navigation
- [ ] Transient pages properly dispose and clean up
- [ ] Singleton pages don't accumulate multiple handlers
- [ ] Rapid navigation doesn't cause issues
- [ ] Hardware back button navigation works
- [ ] Memory usage remains stable during navigation
- [ ] Debug output shows proper lifecycle events