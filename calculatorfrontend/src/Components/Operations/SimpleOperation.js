import React, { useState } from 'react';

const api = "http://localhost:5241/"

const SimpleOperation = ({ endpoint, operation }) => {
    const [firstValue, setFirstValue] = useState('');
    const [secondValue, setSecondValue] = useState('');
    const [result, setResult] = useState('');
    const [error, setError] = useState('');

    const handleCalculate = async () => {
        try {
            const response = await fetch(api + `Calculation/${endpoint}?FirstValue=${firstValue}&SecondValue=${secondValue}`);
            const data = await response.json();

            if (response.ok && data.statusCode == undefined) {
                setResult(` = ${data}`);
                setError('');
            } else {
                setError(data.message)
                setResult('');
            }
        } catch (error) {
            console.error(error);
            
        }
    };

    return (
        <div style={{
            display: 'flex',
            marginBottom: '5vw',
            marginTop: '5vw',
            marginLeft: '10vw'
        }}>
            <input
                type="text"
                value={firstValue}
                onChange={(e) => setFirstValue(e.target.value)}
                style={{
                    width: '10vw', height: '5vw', textAlign: 'center', fontSize: '2vw' }}
            />
            <button style={{
                width: '5vw',
                height: '5vw',
                padding: '1vw',
                border: 'none',
                marginRight: '2vw',
                marginLeft: '2vw',
                fontSize: '2vw',
            }} onClick={handleCalculate}>{operation}</button>
            <input
                type="text"
                value={secondValue}
                onChange={(e) => setSecondValue(e.target.value)}
                style={{
                    width: '10vw',
                    height: '5vw',
                    textAlign: 'center',
                    fontSize: '2vw'
                }}
            />
            <p style={{
                marginLeft: '2vw',
                fontSize: '2vw',
                marginTop: '1vw'
            }}>{result}</p>
            <p style={{
                color: 'red',
                fontSize: '1.5vw',
                marginTop: '1vw'
            }}>{error}</p>
        </div>
    );
};

export default SimpleOperation;