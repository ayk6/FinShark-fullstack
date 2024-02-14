import React, { ChangeEvent, useState, SyntheticEvent } from 'react'
import '.Search.css'

type Props = {
    onSearchSubmit: (e: SyntheticEvent) => void;
    search: string | undefined;
    handleSearchChange: (e: ChangeEvent<HTMLInputElement>) => void;
}

const Search: React.FC<Props> = ({ onSearchSubmit, search, handleSearchChange }: Props): JSX.Element => {

    return (
        <div>
            <input value={search} onChange={(e) => handleSearchChange(e)}></input>
            <button onClick={(e) => console.log(e)}></button>
        </div>
    )
}

export default Search