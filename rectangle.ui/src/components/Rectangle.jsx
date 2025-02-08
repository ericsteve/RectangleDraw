import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { ResizableBox } from 'react-resizable';
import 'react-resizable/css/styles.css';

const Rectangle = () => {
    const [rectangle, setRectangle] = useState({ width: 0, height: 0 });
    const [perimeter, setPerimeter] = useState(0);
    const [error, setError] = useState('');

    useEffect(() => {
        axios.get('https://localhost:7291/api/rectangle')
            .then(response => {
                setRectangle(response.data);
                setPerimeter(2 * (response.data.width + response.data.height));
            });
    }, []);

    const handleResize = (event, { size }) => {
        const { width, height } = size;
        setRectangle({ width, height });
        setPerimeter(2 * (width + height));

        axios.post('https://localhost:7291/api/rectangle', { width, height })
            .then(response => {
                setError('');
            })
            .catch(error => {
                setError(error.response.data);
            });
    };

    return (
        <div>
            <ResizableBox
                width={rectangle.width}
                height={rectangle.height}
                minConstraints={[10, 10]}
                maxConstraints={[500, 500]}
                onResizeStop={handleResize}
                resizeHandles={['se']}
                style={{ border: '1px solid black' }}
            >
                <svg width="100%" height="100%">
                    <rect width="100%" height="100%" fill="gray" />
                </svg>
            </ResizableBox>
            <div>Perimeter: {perimeter}</div>
            {error && <div style={{ color: 'red' }}>{error}</div>}
        </div>
    );
};

export default Rectangle;
