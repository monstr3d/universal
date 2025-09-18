// Simple Event Emitter (Minimal implementation)
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */

class EventEmitter {
    private listeners: { [key: string]: ((data: any) => void)[] } = {};

    on(event: string, listener: (data: any) => void) {
        if (!this.listeners[event]) {
            this.listeners[event] = [];
        }
        this.listeners[event].push(listener);
    }

    off(event: string, listener: (data: any) => void) {
        if (this.listeners[event]) {
            this.listeners[event] = this.listeners[event].filter(l => l !== listener);
        }
    }

    emit(event: string, data?: any) {
        if (this.listeners[event]) {
            this.listeners[event].forEach(listener => listener(data));
        }
    }
}


class MyComponent extends EventEmitter {  // Inherit from EventEmitter
    doSomething() {
        // ... some logic ...
        this.emit('dataChanged', { value: 42 }); // Emit an event
    }

    anotherAction() {
        this.emit('actionCompleted'); // Emit another event
    }
}


// Usage
const myComponent = new MyComponent();

myComponent.on('dataChanged', (data: any) => {
    console.log('Data changed:', data);
});

myComponent.on('actionCompleted', () => {
    console.log('Action completed!');
});


myComponent.doSomething();    // Output: Data changed: { value: 42 }
myComponent.anotherAction();  // Output: Action completed!