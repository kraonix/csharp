const mybooks = [ "Wings of Fire", "The Alchemist", "The Monk who sold his Ferrari" ]
console.log(mybooks);

const updatedBooks = ["The Power of Subconscious Mind" ]

const mergedBooks = [ ...mybooks, ...updatedBooks ]
console.log(mergedBooks);