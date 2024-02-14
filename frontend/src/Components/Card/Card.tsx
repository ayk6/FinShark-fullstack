import React from 'react'
import './Card.css'

type Props = {
    companyName: string;
    ticker: string;
    price: number;
}

const Card: React.FC<Props> = ({ companyName, ticker, price }: Props): JSX.Element => {
    return (
        <div className='card'>
            <img src="https://img.freepik.com/premium-vector/electric-car-concept-illustration-charger-station_625492-28489.jpg?w=826" alt="" />
            <div className='details'>
                <h2>{ticker}</h2>
                <p>${price}</p>
            </div>
            <p className='info'>Lorem ipsum, dolor sit amet consectetur adipisicing elit. Ut, itaque?</p>
        </div>
    )
}

export default Card